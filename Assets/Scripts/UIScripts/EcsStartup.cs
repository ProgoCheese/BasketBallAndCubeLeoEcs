using Leopotam.Ecs;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BasketBall
{
    public class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public SceneData SceneData;
        public Text gameHUDText;
        public Image timerBg;

        // Start is called before the first frame update
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            var entity = _world.NewEntity();
            entity.Get<DisplayTextComponent>();
            entity.Get<TextComponent>().value = gameHUDText;

            var timerEntity = _world.NewEntity();
            timerEntity.Get<TimerBgComponent>().bg = timerBg;
            timerEntity.Get<TimerBgComponent>().timerBg = SceneData.TimerLeft;

            _systems
                .Add(new InitFieldSystem())
                .Add(new CreateGameFieldSystem())
                .Add(new CreateGameBoxSystem())
                .Add(new CreateGameCoinSystem())
                .Add(new InitialFieldCalculatorSystem())
                .Add(new InputGameFieldSystem())
                .Add(new InputTopGameFieldSystem())
                .Add(new InputRigthGameFieldSystem())
                .Add(new InputLeftGameFieldSystem())
                .Add(new InputBottomGameFieldSystem())
                .Add(new CheckBoxColliderSystem())
                .Add(new UpdateTextCubeSystem())
                .Add(new TimerUpdateSystem())
                .Inject(new TextComponent { value = gameHUDText })
                .Inject(SceneData)
                .Init();

        }

        // Update is called once per frame
        void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }

    [Serializable]
    public class CubeLevelData
    {
        public string name;

        public int[] gameField;

        public int length;
    }

    public class CubeLevel
    {
        public string name;
        public int[,] field;
    }
}
