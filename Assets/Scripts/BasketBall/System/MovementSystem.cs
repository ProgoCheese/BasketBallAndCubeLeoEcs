using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBall
{
    public class MovementSystem : IEcsRunSystem
    {
        EcsFilter<ThrowTag, InputDataComponent, MovementComponent, ThrowTypeComponent> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var inputData = ref _filter.Get2(i);
                ref var moveData = ref _filter.Get3(i);
                ref EcsEntity ball = ref _filter.GetEntity(i);

                if (_configuration.isThrow)
                {
                    Vector3 startPos = Camera.main.ScreenToWorldPoint(new Vector3(inputData.StartPosition.x, inputData.StartPosition.y, _configuration.startThrowZ.z));
                    Vector3 endPos = Camera.main.ScreenToWorldPoint(new Vector3(inputData.EndPosition.x, inputData.EndPosition.y, _configuration.endThrowZ.z));

                    Vector3 throwDirection = (endPos - startPos).normalized;

                    if (inputData.Durtion <= 0.3f)
                    {
                        ref var typeData = ref _filter.Get4(i);
                        typeData = ThrowTypeComponent.throwNow;

                        moveData.rb.AddForce(throwDirection * _configuration.throwForce * (0.3f - inputData.Durtion), ForceMode.Impulse);

                        moveData.rb.useGravity = true;

                        //Debug.Log(inputData.Durtion);

                        _configuration.isThrow = false;

                        inputData.ReleaseTime = 0;
                        inputData.PressTime = 0;
                    }


                }
                else
                {
                    moveData.rb.useGravity = true;
                }
            }
        }
    }
}
