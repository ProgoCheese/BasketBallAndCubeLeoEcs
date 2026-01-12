using Leopotam.Ecs;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

namespace BasketBall
{
    internal class InitFieldSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        private EcsWorld _world;

        public void Init()
        { 
            _sceneData.cubeLevel = new CubeLevel[2];
            int j = 1;
            string pathLevel = @"Cude/Level" + j.ToString();
            //Debug.Log(Resources.Load<TextAsset>(pathLevel));
            while(Resources.Load<TextAsset>(pathLevel) != null)
            {
                TextAsset textAsset = Resources.Load<TextAsset>(pathLevel);
                string json = textAsset.text;
                CubeLevelData cubeLevelData = JsonUtility.FromJson<CubeLevelData>(json);

                CubeLevel cubeLevel = new CubeLevel();
                cubeLevel.name = cubeLevelData.name;
                cubeLevel.field = ConvertOneToTwoArray(cubeLevelData.gameField, cubeLevelData.length);
                _sceneData.cubeLevel[j-1] = cubeLevel;
                j+=1;
                pathLevel = @"Cude/Level" + j.ToString();
                //Debug.Log(pathLevel);
                //Debug.Log(Resources.Load<TextAsset>(pathLevel));
            }

            _sceneData.inputStateGame = InputStateGame.Empty;

            _sceneData.Field = _sceneData.cubeLevel[_sceneData.numberLevel-1].field;

            for (int x = 0; x < _sceneData.length; x++)
            {
                for (int y = 0; y < _sceneData.length; y++)
                {
                    EcsEntity cellEntity = _world.NewEntity();
                    cellEntity.Get<CellComponent>().x = x;
                    cellEntity.Get<CellComponent>().y = y;

                    //  Debug.Log(x + " " + y);

                    if (_sceneData.Field[x,y] == 1)
                    {
                        cellEntity.Get<CellComponent>().cellType = CellType.existing;
                    }
                    else if (_sceneData.Field[x,y] == 2)
                    {
                        cellEntity.Get<CellOccupiedComponent>();
                        cellEntity.Get<CellComponent>().cellType = CellType.occupied;
                    }
                    else if (_sceneData.Field[x,y] == 3)
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

        private int[,] ConvertOneToTwoArray(int[] array, int length)
        {
            int[,] gameField = new int[length, length];

            int i = 0;
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    gameField[x, y] = array[i];
                    i++;
                }
            }

            return gameField;
        }
    }
}