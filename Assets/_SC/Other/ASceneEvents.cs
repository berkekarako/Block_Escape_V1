using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SC.Other
{
    public class ASceneEvents : MonoBehaviour
    {
        public AudioSource audioSource;
        
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

        public void ASetGameDifficulty(int num)
        {
            PlayerPrefs.SetInt("Difficulty", num);
        }
        
        public void APlayMomentMusic(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
