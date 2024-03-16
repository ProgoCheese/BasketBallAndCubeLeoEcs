using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    internal class InitFieldSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        private EcsWorld _world;

        public void Init()
        {
            _sceneData.inputStateGame = InputStateGame.Empty;
            for (int x = 0; x < _sceneData.length; x++)
            {
                for (int y = 0; y < _sceneData.length; y++)
                {
                    EcsEntity cellEntity = _world.NewEntity();
                    cellEntity.Get<CellComponent>().x = x;
                    cellEntity.Get<CellComponent>().y = y;

                    //  Debug.Log(x + " " + y);

                    if (_sceneData.Field[x, y] == 1)
                    {
                        cellEntity.Get<CellComponent>().cellType = CellType.existing;
                    }
                    else if (_sceneData.Field[x, y] == 2)
                    {
                        cellEntity.Get<CellOccupiedComponent>();
                        cellEntity.Get<CellComponent>().cellType = CellType.occupied;
                    }
                    else if (_sceneData.Field[x, y] == 3)
                    {
                        cellEntity.Get<GoldComponent>();
                        cellEntity.Get<CellComponent>().cellType = CellType.gold;
                    }
                    else
                    {
                        cellEntity.Get<CellComponent>().cellType = CellType.empty;
                    }

                    if ((x == 1 || x == 0) && (y == 2 || y == 3))
                    {
                        cellEntity.Get<CellComponent>().tagPosition = TagPosition.Top;
                    }
                    else if (x == 4 || x == 5 && (y == 2 || y == 3))
                    {
                        cellEntity.Get<CellComponent>().tagPosition = TagPosition.Bottom;
                    }

                    if ((y == 1 || y == 0) && (x == 2 || x == 3))
                    {
                        cellEntity.Get<CellComponent>().tagPosition = TagPosition.Left;
                    }
                    else if ((y == 4 || y == 5) && (x == 2 || x == 3))
                    {
                        cellEntity.Get<CellComponent>().tagPosition = TagPosition.Right;
                        //Debug.Log("1");
                    }
                }
            }
        }
    }
}