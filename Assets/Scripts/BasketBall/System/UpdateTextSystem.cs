using Leopotam.Ecs;
using UnityEngine;

namespace BasketBall
{
    public class UpdateTextSystem : IEcsRunSystem
    {
        private EcsFilter<TextComponent, DisplayTextComponent>.Exclude<TimerComponent> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var textComponent = ref _filter.Get1(i);
                ref var displayTextComponent = ref _filter.Get2(i);

                displayTextComponent.text = "Счет: " + _configuration.goalСounter.ToString();
                //Debug.Log("asd");
                textComponent.value.text = displayTextComponent.text;
            }
        }
    }
}