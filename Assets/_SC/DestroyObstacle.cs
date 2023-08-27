using System;
using UnityEngine;

namespace _SC
{
    public class DestroyObstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(other.gameObject);
        }
    }
}
