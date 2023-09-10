using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _SC
{
    public class PlayerS : MonoBehaviour
    {
        public List<GameObject> normalMenuButtons;
        public UnityEvent deathSound;
        
        public DestroyObstacle destroyObstacle;

        public AudioSource musicController;
        
        private GameS _gameS;
        
        private void Start()
        {
            _gameS = GameObject.FindWithTag("GameS").GetComponent<GameS>();
        }

        public void Movement(float horizontal)
        {
            if (horizontal == 0) return;
            
            float numberOfColumns = _gameS.numberOfColumns;
            
            float targetVector = transform.position.x + 10 / numberOfColumns * horizontal;

            if (targetVector is > 0 and < 10)
            {
                transform.Translate(10 / numberOfColumns * horizontal, 0, 0);
            }
            else
            {
                if (0 > targetVector)
                {
                    for (int i = 0; i < numberOfColumns - 1; i++)
                    {
                        transform.Translate(10 / numberOfColumns, 0, 0);
                    }
                }
                else
                {
                    for (int i = 0; i < numberOfColumns - 1; i++)
                    {
                        transform.Translate(10 / numberOfColumns * -1, 0, 0);
                    }
                }
            }
        }

        private void Update()
        {
            Movement(Input.GetKeyDown(KeyCode.RightArrow) ? 1 : Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : 0);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Obstacle"))
            {
                if (!_gameS.gameObject.GetComponent<PrizeSpawn>().playerHasBeenPrize)
                {
                    PlayerPrefs.SetInt("Lvl", (int)_gameS.numberOfColumns - 1);
                    PlayerPrefs.SetFloat("LvlNext", _gameS.nextLvlPercent);

                    GetComponent<Animator>().SetTrigger("death");
                    foreach (var normalMenuButton in normalMenuButtons)
                    {
                        normalMenuButton.GetComponent<Button>().enabled = false;
                    }
                    
                    Time.timeScale = 0;
                    
                    musicController.mute = true;
                    deathSound.Invoke();
                    
                    StartCoroutine(LoseGame());
                }
                else
                {
                    _gameS.gameObject.GetComponent<PrizeSpawn>().playerHasBeenPrize = false;
                    destroyObstacle.EnemyHit(other.gameObject);
                    Destroy(other.gameObject);
                }
            }
            
            if (other.collider.CompareTag("Prize"))
            {
                _gameS.gameObject.GetComponent<PrizeSpawn>().playerHasBeenPrize = true;
                Destroy(other.gameObject);
            }
        }

        private IEnumerator LoseGame()
        {
            yield return new WaitForSecondsRealtime(1.5f);
            SceneManager.LoadScene("Finish");
            Time.timeScale = 1f;
        }
    }
}