using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    public class CreateGameFieldSystem : IEcsInitSystem
    {
        private EcsFilter<CellComponent> _filter;
        private SceneData _sceneData;

        public void Init()
        {
            foreach (var i in _filter)
            {
                var cellEnity = _filter.GetEntity(i);
                ref var cellData = ref _filter.Get1(i);

                if (cellData.cellType != CellType.empty)
                {
                    GameObject cellGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cellGameObject.GetComponent<Renderer>().material = _sceneData.CellMaterial[0];
                    cellGameObject.transform.localScale = new Vector3(_sceneData.sizeCell, 0.4f, _sceneData.sizeCell);
                    cellGameObject.transform.position = new Vector3(_sceneData.spawnTransform.position.x + (_sceneData.sizeCell + 0.1f) * cellData.x, _sceneData.spawnTransform.position.y, _sceneData.spawnTransform.position.y + (_sceneData.sizeCell + 0.1f) * cellData.y);
                    cellData.gameObject = cellGameObject;
                    cellGameObject.GetComponent<BoxCollider>().size = new Vector3(_sceneData.sizeCell, 3f, _sceneData.sizeCell);

                    if (cellData.tagPosition == TagPosition.Top)
                    {
                        cellGameObject.tag = "TopCell";
                    }
                    else if (cellData.tagPosition == TagPosition.Bottom)
                    {
                        cellGameObject.tag = "BottomCell";
                    }
                    else if (cellData.tagPosition == TagPosition.Left)
                    {
                        cellGameObject.tag = "LeftCell";
                    }
                    else if (cellData.tagPosition == TagPosition.Right)
                    {
                        cellGameObject.tag = "RigthCell";
                    }

                    /*
                    if(cellData.cellType == CellType.occupied)
                    {
                        GameObject boxGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        boxGameObject.GetComponent<Renderer>().material = _sceneData.CellMaterial[0];
                        boxGameObject.transform.localScale = new Vector3(_sceneData.sizeCell - 0.1f, 0.6f, _sceneData.sizeCell - 0.1f);
                        boxGameObject.transform.position = new Vector3(_sceneData.spawnTransform.position.x + (_sceneData.sizeCell + 0.1f) * cellData.x, _sceneData.spawnTransform.position.y, _sceneData.spawnTransform.position.y + (_sceneData.sizeCell + 0.1f) * cellData.y);
                        cellEnity.Get<CellOccupiedComponent>
                    }*/
                }
            }
        }
    }
}