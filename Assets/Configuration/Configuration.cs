using UnityEngine;

namespace BasketBall
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public GameObject ball;
        public GameObject basket;

        public Transform[] spawnBall;
        public Transform[] spawnPoint;
        public int[] needThrowNextLevel;
        public float[] needTime;

        public Transform spawnBasket;

        public Rigidbody rd;

        public float throwForce;
        
        public Vector3 startThrowZ;
        public Vector3 endThrowZ;

        public bool isThrow;
        public int goal—ounter = 0;

        public ParticleSystem particle;

        public int LevelGame = 0;

        public Camera camera;
    }
}