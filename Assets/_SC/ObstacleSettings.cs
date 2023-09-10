using System;
using TMPro;
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
                _gameS.SpawnEnemy();
            }
            
            //fpsText.text = (1 / Time.deltaTime).ToString("F0");
        }

        public void MakeGameHarder()
        {
            switch (_difficultyNumber)
            {
                case 0:
                    obstacleSpawnTime /= 1.25f;
                    break;
                
                case 1:
                    obstacleSpawnTime /= 1.325f;
                    break;
                
                case 2:
                    obstacleSpawnTime /= 1.475f;
                    break;
            }
        }
    }
}
