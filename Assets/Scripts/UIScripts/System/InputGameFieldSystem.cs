using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    public class InputGameFieldSystem : IEcsRunSystem
    {
        private EcsFilter<CellOccupiedComponent, CellComponent> _filter;
        private SceneData _sceneData;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var camera = Camera.main;
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    var cellView = hitInfo.collider.tag;
                    if (cellView == "TopCell")
                    {
                        _sceneData.inputStateGame = InputStateGame.Top;
                    }
                    else if (cellView == "RigthCell")
                    {
                        _sceneData.inputStateGame = InputStateGame.Right;
                        //Debug.Log(_sceneData.inputStateGame);
                    }
                    else if (cellView == "BottomCell")
                    {
                        _sceneData.inputStateGame = InputStateGame.Bottom;
                        //Debug.Log(_sceneData.inputStateGame);
                    }
                    else if (cellView == "LeftCell")
                    {
                        _sceneData.inputStateGame = InputStateGame.Left;
                        //Debug.Log(_sceneData.inputStateGame);
                    }
                    //Debug.Log(cellView);
                }
            }
            /*
            if (isGo)
            {
                foreach (var i in _filter)
                {
                    ref var cellOccupiedData = ref _filter.Get1(i);
                    ref var cellData = ref _filter.Get2(i);

                    Vector3 targetPosition = new Vector3(cellData.gameObject.transform.position.x + 2 * (_sceneData.sizeCell + 0.1f), cellData.gameObject.transform.position.y, cellData.gameObject.transform.position.z);

                    cellOccupiedData.box.transform.position = Vector3.Lerp(cellOccupiedData.box.transform.position, targetPosition, _sceneData.speedBox * Time.deltaTime);

                    //Debug.Log(targetPosition + " " + cellOccupiedData.box.transform.position);

                    if (targetPosition == cellOccupiedData.box.transform.position)
                    {
                        isGo = false;
                    }
                }
            }
            */
        }
    }
}