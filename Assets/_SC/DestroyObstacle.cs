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
            destroyObjNumber++;
            other.gameObject.SetActive(false);
            
            games.notActiveEnemy.Add(other.gameObject);
            games.activeEnemy.Remove(other.gameObject);
            
            games.TryNextLvl(destroyObjNumber);
        }
    }
}
