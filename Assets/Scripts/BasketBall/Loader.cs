using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

namespace BasketBall
{
    public class Loader : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public Text gameHUDText;
        public Text gameTimerText;
        public float timerCount;
        public Camera Camera;

        // Start is called before the first frame update
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            var entity = _world.NewEntity();
            ref var textComponent = ref entity.Get<DisplayTextComponent>();
            entity.Get<TextComponent>().value = gameHUDText;

            var timerEntity = _world.NewEntity();
            ref var timer = ref timerEntity.Get<TimerComponent>();
            ref var textTimerComponent = ref timerEntity.Get<DisplayTextComponent>();
            timerEntity.Get<TextComponent>().value = gameTimerText;
            timer.TimeLeft = timerCount;

            _systems
                .Add(new GameInitSystem())
                //.Add(new GameObjectCreationSystem())
                .Add(new BallThrowSystem())
                .Add(new InputSystem())
                .Add(new MovementSystem())
                .Add(new CollisionDetectionSystem())
                .Add(new SetCameraPosition())
                //.Add(new GetNormalStateSystem())
                .Add(new InputGameKeySystem())
                .Add(new UpdateTextSystem())
                .Add(new TimerSystem())
                .Add(new UpdateTimerTextSystem())
                //.OneFrame<DisplayTextComponent>()
                .Inject(new TextComponent { value = gameHUDText })
                .Inject(new TextComponent { value = gameTimerText })
                .Inject(Configuration)
                .Init();

            Configuration.goal—ounter = 0;
            Configuration.camera = Camera;
        }

        // Update is called once per frame
        void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}
