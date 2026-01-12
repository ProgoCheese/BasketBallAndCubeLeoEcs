using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    internal class GameInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private Configuration _configuration;

        public void Init()
        {
            _configuration.LevelGame = 0;

            GameObject ballGameObject = GameObject.Instantiate(_configuration.ball);
            ballGameObject.transform.position = _configuration.spawnBall[0].position;
            Rigidbody rb = ballGameObject.GetComponent<Rigidbody>();
            Collider collider = ballGameObject.GetComponent<Collider>();
            Transform transform = ballGameObject.GetComponent<Transform>();
            rb.useGravity = false;

            var ball = _world.NewEntity();
            ref var inputDataComponent = ref ball.Get<InputDataComponent>();
            ball.Get<MovementComponent>().rb = rb;
            ball.Get<ThrowTypeComponent>() = ThrowTypeComponent.peace;
            ball.Get<InputDataComponent>();
            ball.Get<InputDataComponent>().collider = collider;
            ball.Get<InputDataComponent>().transform = transform;
        }
    }
}