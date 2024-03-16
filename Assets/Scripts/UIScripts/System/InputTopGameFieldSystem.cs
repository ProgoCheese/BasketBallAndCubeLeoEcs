using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    public class InputTopGameFieldSystem : IEcsRunSystem
    {
        private EcsFilter<CellOccupiedComponent, CellComponent> _filter;
        private SceneData _sceneData;
        private bool isGo = false;
        private bool isFirstTime = false;

        public void Run()
        {
            if (_sceneData.inputStateGame == InputStateGame.Top && !isFirstTime)
            {
                isGo = true;
            }

            if (isGo)
            {
                foreach (var i in _filter)
                {
                    ref var cellData = ref _filter.Get2(i);
                    if (cellData.tagPosition == TagPosition.Top && cellData.gameObject != null)
                    {
                        ref var cellOccupiedData = ref _filter.Get1(i);

                        Vector3 targetPosition = new Vector3(cellData.gameObject.transform.position.x + 2 * (_sceneData.sizeCell + 0.1f), cellData.gameObject.transform.position.y, cellData.gameObject.transform.position.z);

                        cellOccupiedData.box.transform.position = Vector3.Lerp(cellOccupiedData.box.transform.position, targetPosition, _sceneData.speedBox * Time.deltaTime);

                        //Debug.Log(targetPosition + " " + cellOccupiedData.box.transform.position);

                        if (targetPosition.x == cellOccupiedData.box.transform.position.x)
                        {
                            isGo = false;
                            isFirstTime = true;
                        }
                    }

                }
            }


        }
    }
}