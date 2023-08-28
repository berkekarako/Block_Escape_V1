using UnityEngine;

namespace _SC
{
    public class ObstacleSettings : MonoBehaviour
    {
        public float obstacleSpawnTime;
        
        private GameS _gameS;
        private float _x;

        private int _difficultyNumber;
        
        private void Start()
        {
            _gameS = GameObject.FindWithTag("GameS").GetComponent<GameS>();
            _difficultyNumber = PlayerPrefs.GetInt("Difficulty");
        }

        private void Update()
        {
            _x += Time.deltaTime;

            if (_x >= obstacleSpawnTime)
            {
                _x = 0;
                _gameS.SpawnCube();
            }
        }

        public void MakeGameHarder()
        {
            switch (_difficultyNumber)
            {
                case 0:
                    obstacleSpawnTime /= 1.375f;
                    break;
                
                case 1:
                    obstacleSpawnTime /= 1.5f;
                    break;
                
                case 2:
                    obstacleSpawnTime /= 1.63f;
                    break;
            }
        }
    }
}
