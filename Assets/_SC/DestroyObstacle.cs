using System;
using UnityEngine;

namespace _SC
{
    public class DestroyObstacle : MonoBehaviour
    {
        public int destroyObjNumber;
        public GameS games;
            
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Prize"))
            {
                Destroy(other.gameObject);
            }
            
            if(!other.gameObject.CompareTag("Obstacle")) return;
            destroyObjNumber++;
            other.gameObject.SetActive(false);
            
            games.notActiveEnemy.Add(other.gameObject);
            games.activeEnemy.Remove(other.gameObject);
            
            games.TryNextLvl(destroyObjNumber);
        }
    }
}
