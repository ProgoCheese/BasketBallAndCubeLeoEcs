using Leopotam.Ecs;
using UnityEngine;


namespace BasketBall
{
    internal class GetNormalStateSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<ThrowTypeComponent,MovementComponent>.Exclude<ThrowTag> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var typeData = ref _filter.Get1(i);
                ref var moveData = ref _filter.Get2(i);

                if (typeData == ThrowTypeComponent.peace)
                {
                    Debug.Log("asd");
                    moveData.rb.useGravity = false;
                }
            }
        }
    }
}