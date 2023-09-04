using System;
using UnityEngine;
using UnityEngine.UI;

namespace _SC
{
    public class ChangeAllSprites : MonoBehaviour
    {
        public ChangeSprites[] changeSprites;
        public ChangeImageSprites[] changeImageSprites;
        
        void Start()
        {
            ChangeAllSprite();
            ChangeAllImageSource();
            PlayerPrefs.SetInt("SpriteSettings", 1);
        }
        
        private void ChangeAllSprite()
        {
            switch (PlayerPrefs.GetInt("SpriteSettings"))
            {
                case 1:
                    print("asdasdasdasdas");
                    for (int i = 0; i < changeSprites.Length; i++)
                    {
                        changeSprites[i].obj.sprite = changeSprites[i].sprite1;
                    }
                    break;
                
                case 2:
                    for (int i = 0; i < changeSprites.Length; i++)
                    {
                        changeSprites[i].obj.sprite = changeSprites[i].sprite2;
                    }
                    break;
            }
        }
        
        private void ChangeAllImageSource()
        {
            switch (PlayerPrefs.GetInt("SpriteSettings"))
            {
                case 1:
                    print("asdasdasdasdas");
                    for (int i = 0; i < changeImageSprites.Length; i++)
                    {
                        changeImageSprites[i].obj.sprite = changeImageSprites[i].sprite1;
                    }
                    break;
                
                case 2:
                    for (int i = 0; i < changeImageSprites.Length; i++)
                    {
                        changeImageSprites[i].obj.sprite = changeImageSprites[i].sprite2;
                    }
                    break;
            }
        }
    }

    [Serializable]
    public class ChangeSprites
    {
        public SpriteRenderer obj;
        public Sprite sprite1;
        public Sprite sprite2;
    }
    
    [Serializable]
    public class ChangeImageSprites
    {
        public Image obj;
        public Sprite sprite1;
        public Sprite sprite2;
    }
}
