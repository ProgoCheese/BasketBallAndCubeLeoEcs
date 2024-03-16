using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBall
{
    public struct InputDataComponent
    {
        public Vector3 StartPosition;
        public Vector3 EndPosition;

        public float PressTime;
        public float ReleaseTime;

        public float Durtion => ReleaseTime - PressTime;

        public GameObject GameObject;

        public Collider collider;

        public Transform transform; 
    }
}
