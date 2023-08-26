using UnityEngine;

namespace _SC
{
    public class PlayerMovement : MonoBehaviour
    {
        private GameS _gameS;
        
        private void Start()
        {
            _gameS = GameObject.FindWithTag("GameS").GetComponent<GameS>();
        }

        public void Movement(float horizontal)
        {
            float numberOfColumns = _gameS.numberOfColumns;
            
            float targetVector = transform.position.x + 10 / numberOfColumns * horizontal;
            print(targetVector);

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
    }
}
