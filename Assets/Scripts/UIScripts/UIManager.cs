using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BasketBall
{
    public class UIManager : MonoBehaviour
    {
        public void GetIndexScene(int id)
        {
            SceneManager.LoadScene(id);
        }
    }
}
