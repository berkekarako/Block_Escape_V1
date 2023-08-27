using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SC
{
    public class PlayerS : MonoBehaviour
    {
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
                SceneManager.LoadScene("Finish");
            }
        }
    }
}