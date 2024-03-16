using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    public class InputRigthGameFieldSystem : IEcsRunSystem
    {
        private EcsFilter<CellOccupiedComponent, CellComponent> _filter;
        private SceneData _sceneData;
        private bool isGo = false;
        private bool isFirstTime = false;

        public void Run()
        {
            if (_sceneData.inputStateGame == InputStateGame.Right && !isFirstTime)
            {
                isGo = true;
            }

            if (isGo)
            {
                foreach (var i in _filter)
                {
                    ref var cellData = ref _filter.Get2(i);
                    if (cellData.tagPosition == TagPosition.Right && cellData.gameObject != null)
                    {
                        ref var cellOccupiedData = ref _filter.Get1(i);

                        Vector3 targetPosition = new Vector3(cellData.gameObject.transform.position.x, cellData.gameObject.transform.position.y, cellData.gameObject.transform.position.z - 2 * (_sceneData.sizeCell + 0.1f));

                        if (cellData.gameObject != null)
                        {
                            cellOccupiedData.box.transform.position = Vector3.Lerp(cellOccupiedData.box.transform.position, targetPosition, _sceneData.speedBox * Time.deltaTime);
                        }
                        else
                        {
                            break;
                        }

                        isFirstTime = true;
                    }

                }
            }


        }
    }
}