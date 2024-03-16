using Leopotam.Ecs;

namespace BasketBall
{
    internal class UpdateTimerTextSystem : IEcsRunSystem
    {
        private EcsFilter<TextComponent, DisplayTextComponent,TimerComponent> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var textComponent = ref _filter.Get1(i);
                ref var displayTextComponent = ref _filter.Get2(i);
                ref var timer = ref _filter.Get3(i);

                int min = (int)timer.TimeLeft / 60;
                int sec = (int)timer.TimeLeft % 60;

                displayTextComponent.text = string.Format("{0:00}:{1:00}", min,sec);
                //Debug.Log("asd");
                textComponent.value.text = displayTextComponent.text;
            }
        }
    }
}