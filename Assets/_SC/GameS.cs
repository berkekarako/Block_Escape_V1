using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;
using UnityEngine.UI;

namespace _SC
{
    public class GameS : MonoBehaviour
    {
        public delegate void MakeGameHarderHandler();
        public static event MakeGameHarderHandler MakeGameHarderEvent;
        
        [Serializable] public struct AllEnemies
        {
            public GameObject enemy;
            public int probability;
        }
        
        public GameObject player;
        public GameObject columnPref;
        public float numberOfColumns = 2; // Aralardaki Boşluk Sayısı
        public float shrinkageX;
        
        [Header("UI")]
        public TextMeshProUGUI scoreText;
        public Text scoreText_1;
        public Image nextLvlImage;
        public List<Sprite> uploadSprites;
        public Sprite defaultUploadSprites;
        public int nextLvlNumber = 1;
        public float nextLvlPercent;

        [Header("Objects")]
        public List<GameObject> columns;
        public DestroyObstacle destroyObstacle;
        public float maxEnemyNumber = 10;
        public float usedEnemyNumber;
        
        [Header("Camera")]
        public Camera mainCamera;
        public LayerMask normalCullingMask;
        public LayerMask pausedCullingMask;
        
        [Header("Enemy")]
        public List<AllEnemies> allEnemies = new();
        private List<GameObject> _enemiesProbability = new();

        private void Awake()
        {
            MakeGameHarderEvent = null;
        }

        private void Start()
        {
            Time.timeScale = 1;
            player.transform.position = new Vector3(2.5f, -5.625f, 0);

            for (int i = 0; i < allEnemies.Count; i++)
            {
                for (int j = 0; j < allEnemies[i].probability; j++)
                {
                    _enemiesProbability.Add(allEnemies[i].enemy);
                }
            }
        }

        public void ColumAdd()
        {
            numberOfColumns++;
            columns.Add(Instantiate(columnPref));

            float s = 0f;
            
            for (int i = 0; i < numberOfColumns - 1; i++) // Kolon Düzeneleme
            {
                columns[i].transform.position = new Vector3(s + 10/numberOfColumns, 0.49f, 0);
                s += 10 / numberOfColumns;
            }

            if (numberOfColumns % 2 != 0) // Kolon eklenince karakteri ışınlama
            {
                player.transform.position = new Vector3(5, -5.5f, 0);
            }
            else
            {
                player.transform.position = new Vector3(5 + 10 / numberOfColumns / 2, -5.5f, 0);
            }
            
            maxEnemyNumber *= 1.75f;
            usedEnemyNumber = 0;

            // Diğer Ayarlar
            MakeGameHarderEvent?.Invoke();

            player.transform.localScale /= shrinkageX;

            scoreText.text = (numberOfColumns - 1).ToString(CultureInfo.InvariantCulture);
            scoreText_1.text = (numberOfColumns - 1).ToString(CultureInfo.InvariantCulture);
        }
        
        public void SpawnEnemy()
        {
            if ((int)maxEnemyNumber >= usedEnemyNumber + 1)
            {
                usedEnemyNumber++;
                
                SpawnRandomEnemy(out GameObject usedObstacle);

                float randomNumber = Random.Range(0, (int)numberOfColumns);
                float targetVec = 10 / numberOfColumns / 2 + randomNumber * 10 / numberOfColumns;

                usedObstacle.transform.position = new Vector3(targetVec, Random.Range(11f, 20f), 0);
            }
        }

        private void SpawnRandomEnemy(out GameObject usedObstacle)
        {
            var randomNumber = Random.Range(0, _enemiesProbability.Count);
            var obstacle = Instantiate(_enemiesProbability[randomNumber]);
            
            obstacle.GetComponent<Enemies>().ChangeSprite();
            
            usedObstacle = obstacle;
        }
        
        public void TryNextLvl(int destroyObjNumber)
        {
            nextLvlPercent = (float)destroyObjNumber * 100 / (int)maxEnemyNumber;
            //nextLvlText.text = numberNextLvl.ToString(CultureInfo.InvariantCulture) + "%";
            print(nextLvlPercent);

            if(nextLvlPercent >= nextLvlNumber * 10)
            {
                nextLvlImage.sprite = uploadSprites[nextLvlNumber - 1];
                nextLvlNumber++;
            }
            
            if (destroyObjNumber == (int)maxEnemyNumber)
            {
                ColumAdd();
                destroyObstacle.destroyObjNumber = 0;
                nextLvlNumber = 1;
                nextLvlImage.sprite = defaultUploadSprites;
            }
        }

        public void PauseGame()
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                mainCamera.cullingMask = normalCullingMask;
            }
            else
            {
                Time.timeScale = 0;
                mainCamera.cullingMask = pausedCullingMask;
            }
        }
    }
}
