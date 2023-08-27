using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SC.Other
{
    public class ASceneEvents : MonoBehaviour
    {
        public void ASceneLoad(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void AExitGame()
        {
            Application.Quit();
        }

        public void AOpen(GameObject obj)
        {
            obj.SetActive(true);
        }
        
        public void AClose(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}