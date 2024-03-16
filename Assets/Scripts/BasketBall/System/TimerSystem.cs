using Leopotam.Ecs;

namespace BasketBall
{
    internal class TimerSystem : IEcsRunSystem
    {
        private EcsFilter<TimerComponent> _filter;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var timer = ref _filter.Get1(i);
                timer.TimeLeft -= UnityEngine.Time.deltaTime;

                if(timer.TimeLeft < 0 )
                {
                    timer.TimeLeft = 0;
                }
            }
        }
    }
}