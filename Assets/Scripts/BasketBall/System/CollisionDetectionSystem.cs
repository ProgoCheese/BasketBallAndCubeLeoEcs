using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace BasketBall
{
    public class CollisionDetectionSystem : IEcsRunSystem
    {
        EcsWorld _world;
        EcsFilter<InputDataComponent, ThrowTag,MovementComponent> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var ball = ref _filter.GetEntity(i);

                ref var inputData = ref _filter.Get1(i);
                ref var moveData = ref _filter.Get3(i);
                //ref var moveData = ref _filter.Get3(i);
                Collider[] hitColliders = Physics.OverlapBox(inputData.transform.position, inputData.collider.bounds.size / 2f, inputData.transform.rotation);
                if (hitColliders != null)
                {
                    foreach (Collider collider in hitColliders)
                    {
                        if (collider.tag == "Backet")
                        {
                            //inputData.rb.useGravity = false;
                            inputData.transform.position = _configuration.spawnBall.transform.position;
                            _configuration.goal�ounter += 1;
                            moveData.rb.useGravity = false;
                            moveData.rb.isKinematic = true;
                            moveData.rb.isKinematic = false;
                            ball.Del<ThrowTag>();

                           // Debug.Log("�����");

                            GameObject particle = new GameObject("Particle");
                            particle.transform.position = _configuration.spawnBasket.transform.position;
                            ParticleSystem particleSystem = particle.AddComponent<ParticleSystem>();
                            var mainModule = particleSystem.main;
                            mainModule.startLifetime = 1f;
                            mainModule.startSpeed = 5f;
                            mainModule.startSize = 0.5f;
                            mainModule.startColor = Color.yellow;
                            particleSystem.Play();
                            GameObject.Destroy(particle, 2f);
                        }
                        else if (collider.tag == "Wall")
                        {
                            Debug.Log("����");
                            inputData.transform.position = _configuration.spawnBall.transform.position;
                            ball.Del<ThrowTag>();
                            moveData.rb.useGravity = false;
                            moveData.rb.isKinematic = true;
                            moveData.rb.isKinematic = false;
                        }
                    }
                }


            }
        }
    }
}
