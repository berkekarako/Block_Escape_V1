using UnityEngine;

namespace _SC
{
    public class ObstacleSettings : MonoBehaviour
    {
        public float obstacleSpawnTime;
        public float obstacleSpawnTimeX = 1.33f;
        
        private GameS _gameS;
        private float _x;
        
        private void Start()
        {
            _gameS = GameObject.FindWithTag("GameS").GetComponent<GameS>();
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
            obstacleSpawnTime /= obstacleSpawnTimeX; // Her seferinde 1.33 kat hızlancak
        }
    }
}