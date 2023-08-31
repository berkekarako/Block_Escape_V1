using UnityEngine;

namespace _SC
{
    public class Skeleton : MonoBehaviour
    {
        public float shrnkingTime;
        
        public void Skeletonn()
        {
            transform.localScale /= shrnkingTime;
        }
    }
}
