using System.Collections.Generic;
using UnityEngine;

namespace _SC
{
    public class Enemies : MonoBehaviour
    {
        public List<Sprite> sprites;
        public float shrinkageRate;
        
        public void Shrinkage()
        {
            transform.localScale /= shrinkageRate;
        }
        
        public void ChangeSprite()
        {
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        }
    }
}