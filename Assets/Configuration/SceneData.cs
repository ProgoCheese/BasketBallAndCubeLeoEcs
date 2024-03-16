using UnityEngine;

namespace BasketBall
{
    [CreateAssetMenu]
    public class SceneData : ScriptableObject
    {
        public int[,] Field = {
            {0,0,1,2,0,0 },
            {0,0,1,1,0,0 },
            {2,1,3,1,1,1 },
            {1,1,1,3,1,2 },
            {0,0,1,1,0,0 },
            {0,0,2,2,0,0 }};

        public Material[] CellMaterial;

        /* public int[,] Field = {
            {0,0,0,1,1,1,0,0,0 },
            {0,0,0,1,1,1,0,0,0 },
            {0,0,0,1,1,1,0,0,0 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {0,0,0,1,1,1,0,0,0 },
            {0,0,0,1,1,1,0,0,0 },
            {0,0,0,1,1,1,0,0,0 },}; */

        public GameObject cubeFloor;

        public float sizeCell;

        public Transform spawnTransform;

        public int length;

        public float speedBox = 0.5f;

        public InputStateGame inputStateGame;

        public int CoinCounter = 0;
    }
}