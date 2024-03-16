using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    public class CreateGameBoxSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter<CellOccupiedComponent, CellComponent> _filter;
        private SceneData _sceneData;

        public void Init()
        {
            foreach (var i in _filter)
            {
                var cellEnity = _filter.GetEntity(i);
                ref var cellOccupiedData = ref _filter.Get1(i);
                ref var cellData = ref _filter.Get2(i);

                GameObject boxGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                boxGameObject.GetComponent<Renderer>().material = _sceneData.CellMaterial[1];
                boxGameObject.GetComponent<Rigidbody>();
                boxGameObject.tag = "Box";
                boxGameObject.transform.localScale = new Vector3(_sceneData.sizeCell - 0.1f, 0.6f, _sceneData.sizeCell - 0.1f);
                boxGameObject.transform.position = new Vector3(_sceneData.spawnTransform.position.x + (_sceneData.sizeCell + 0.1f) * cellData.x, _sceneData.spawnTransform.position.y + 0.1f, _sceneData.spawnTransform.position.y + (_sceneData.sizeCell + 0.1f) * cellData.y);
                cellOccupiedData.box = boxGameObject;
                cellOccupiedData.collider = boxGameObject.GetComponent<Collider>();
                
            }
        }
    }
}