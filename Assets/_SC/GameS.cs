using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _SC
{
    public class GameS : MonoBehaviour
    {
        public GameObject columnPref;
        public GameObject player;
        public GameObject cubePref;
        public float numberOfColumns = 2; // Aralardaki Boşluk Sayısı
        public float shrinkageX;

        public List<GameObject> columns;

        private void Start()
        {
            player.transform.position = new Vector3(2.5f, -5.75f, 0);
        }

        public void ColumAdd()
        {
            numberOfColumns++;
            columns.Add(Instantiate(columnPref));

            float s = 0f;
            
            for (int i = 0; i < numberOfColumns - 1; i++)
            {
                columns[i].transform.position = new Vector3(s + 10/numberOfColumns, 3.5f, 0);
                s += 10 / numberOfColumns;
            }

            if (numberOfColumns % 2 != 0)
            {
                player.transform.position = new Vector3(5, -5.75f, 0);
            }
            else
            {
                player.transform.position = new Vector3(5 + 10 / numberOfColumns / 2, -5.75f, 0);
            }

            GetComponent<ObstacleSpawn>().MakeGameHarder();

            player.transform.localScale = new Vector3(10 / numberOfColumns / shrinkageX / 2,
                10 / numberOfColumns / shrinkageX / 2, 10 / numberOfColumns / shrinkageX / 2);
        }
        
        public void SpawnCube()
        {
            //int cubeNumber = Random.Range(1, (int)numberOfColumns); Şuan 1 tane spawnlanıyor yarın ayarlicam
            
            int cubeNumber = 1;
            
            while (cubeNumber != 0)
            {
                float randomNumber = Random.Range(0, (int)numberOfColumns);
                
                float targetVec = 10 / numberOfColumns / 2 + randomNumber * 10 / numberOfColumns;
                
                Instantiate(cubePref, new Vector3(targetVec, 11, 0), Quaternion.identity);
                
                cubeNumber--;
            }
        }
    }
}
