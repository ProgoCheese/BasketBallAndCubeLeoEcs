using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBall
{
    public class BallThrowSystem : IEcsRunSystem
    {
        private EcsFilter<InputDataComponent>.Exclude<ThrowTag> _filter;
        private EcsWorld _world;
        private Configuration _configuration;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var inputData = ref _filter.Get1(i);

                if(inputData.ReleaseTime > 0.00001f)
                {
                    var direction = inputData.EndPosition - inputData.StartPosition;
                    var duration = inputData.Durtion;

                    _filter.GetEntity(i).Get<ThrowTag>();

                    //Debug.Log("Ѕросок в болл");

                    _configuration.isThrow = true;
                }
                else
                {
                    _configuration.isThrow = false;
                }
            }
        }
    }

    public struct ThrowTag
    {
    }
}
