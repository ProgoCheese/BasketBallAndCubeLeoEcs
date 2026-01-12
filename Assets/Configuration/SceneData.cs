using UnityEngine;

namespace BasketBall
{
    /// <summary>
    /// кубик
    /// </summary>
    [CreateAssetMenu]
    public class SceneData : ScriptableObject
    {
        public int[,] Field;

        public int numberLevel;

        public CubeLevel[] cubeLevel;

        public Material[] CellMaterial;

        public GameObject cubeFloor;

        public float sizeCell;

        public Transform spawnTransform;

        public int length;

        public float speedBox = 0.5f;

        public InputStateGame inputStateGame;

        public int CoinCounter = 0;

        public float TimerLeft;
    }
}