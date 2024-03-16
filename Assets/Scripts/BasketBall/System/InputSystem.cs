using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBall
{
    public class InputSystem : IEcsRunSystem
    {
        private EcsFilter<InputDataComponent> _filter;
        private Configuration _configuration;
        private EcsWorld _world;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var inputData = ref _filter.Get1(i);
                if (Input.GetMouseButtonDown(0))
                {
                    inputData.StartPosition = Input.mousePosition;
                    inputData.StartPosition.z = _configuration.startThrowZ.z;

                    inputData.PressTime = Time.time;

                    //Debug.Log(inputData.PressTime);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    inputData.EndPosition = Input.mousePosition;
                    inputData.EndPosition.z = _configuration.endThrowZ.z;
                    inputData.ReleaseTime = Time.time;
                }
            }
        }
    }
}
