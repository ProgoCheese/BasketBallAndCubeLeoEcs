using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BasketBall
{
    public class InputGameKeySystem : IEcsRunSystem
    {
        public void Run()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}