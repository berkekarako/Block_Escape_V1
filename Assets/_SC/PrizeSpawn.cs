using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _SC
{
    public class PrizeSpawn : MonoBehaviour
    {
        public GameObject prize;
        public bool playerHasBeenPrize;
        public float harderX;
        public GameS gameS;
        
        public float maxPrizeSpawnRate = 1000000;
            
        public void ChangeRate(int maxRate)
        {
            maxPrizeSpawnRate = maxRate;
        }

        private void Start()
        {
            Invoke(nameof(TrySpawnPrize), 1);
        }

        private void TrySpawnPrize()
        {
            if (!playerHasBeenPrize)
            {
                if (Random.Range(0, (int)maxPrizeSpawnRate) == 1)
                {
                    float randomNumber = Random.Range(0, (int)gameS.numberOfColumns);

                    float targetVec = 10 / gameS.numberOfColumns / 2 + randomNumber * 10 / gameS.numberOfColumns;
                    
                    Instantiate(prize).transform.position = new Vector3(targetVec, Random.Range(11f, 20f), 0);
                }
            }
            
            Invoke(nameof(TrySpawnPrize), 1);
        }
        
        public void MakeGameHarder()
        {
            maxPrizeSpawnRate /= harderX;
        }
    }
}