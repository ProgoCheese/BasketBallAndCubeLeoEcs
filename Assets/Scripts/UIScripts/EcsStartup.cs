using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

namespace BasketBall
{
    public class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public SceneData SceneData;

        // Start is called before the first frame update
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

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
}
