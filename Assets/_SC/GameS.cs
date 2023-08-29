using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace _SC
{
    public class GameS : MonoBehaviour
    {
        public GameObject player;
        public GameObject columnPref;
        public float numberOfColumns = 2; // Aralardaki Boşluk Sayısı
        public float shrinkageX;
        
        [Header("UI")]
        public TextMeshProUGUI scoreText;
        public Image nextLvlImage;
        public List<Sprite> uploadSprites;
        public Sprite defaultUploadSprites;
        public int nextLvlNumber = 1;

        [Header("Objects")]
        public List<GameObject> columns;
        public List<GameObject> obstacles;
        public int obstacleNumberUsed = -1;
        public DestroyObstacle destroyObstacle;

        [Header("Camera")]
        public Camera mainCamera;
        public LayerMask normalCullingMask;
        public LayerMask pausedCullingMask;
        
        [Header("Enemy")]
        public GameObject enemyPref;
        public List<Sprite> enemySprites;

        private void Start()
        {
            Time.timeScale = 1;
            player.transform.position = new Vector3(2.5f, -5.625f, 0);
            
            for (int i = 0; i < 10; i++)
            {
                GameObject newObstacle = Instantiate(enemyPref);
                newObstacle.SetActive(false);
                obstacles.Add(newObstacle);
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
                player.transform.position = new Vector3(5, -5.625f, 0);
            }
            else
            {
                player.transform.position = new Vector3(5 + 10 / numberOfColumns / 2, -5.625f, 0);
            }

            int totalObstacleNumber = obstacles.Count;
            for (int i = 0; i < totalObstacleNumber; i++) // Engel Çoğaltma
            {
                GameObject newObstacle = Instantiate(enemyPref);
                newObstacle.SetActive(false);
                obstacles.Add(newObstacle);
            }
            obstacleNumberUsed = -1;

            // Diğer Ayarlar
            GetComponent<ObstacleSettings>().MakeGameHarder();

            player.transform.localScale = new Vector3(10 / numberOfColumns / shrinkageX,
                10 / numberOfColumns / shrinkageX, 10 / numberOfColumns / shrinkageX);

            scoreText.text = (numberOfColumns - 1).ToString(CultureInfo.InvariantCulture);
        }
        
        public void SpawnEnemy()
        {
            if (obstacles.Count > obstacleNumberUsed + 1)
            {
                obstacleNumberUsed++;
                var usedObstacle = obstacles[obstacleNumberUsed];
                usedObstacle.SetActive(true);

                usedObstacle.GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Count - 1)];

                float randomNumber = Random.Range(0, (int)numberOfColumns);

                float targetVec = 10 / numberOfColumns / 2 + randomNumber * 10 / numberOfColumns;

                usedObstacle.transform.position = new Vector3(targetVec, Random.Range(11f, 20f), 0);
            }
        }
        
        public void TryNextLvl(int destroyObjNumber)
        {
            float numberNextLvl = (float)destroyObjNumber * 100 / obstacles.Count;
            //nextLvlText.text = numberNextLvl.ToString(CultureInfo.InvariantCulture) + "%";

            if(numberNextLvl >= nextLvlNumber * 10)
            {
                nextLvlImage.sprite = uploadSprites[nextLvlNumber - 1];
                nextLvlNumber++;
            }
            
            if (destroyObjNumber == obstacles.Count)
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
