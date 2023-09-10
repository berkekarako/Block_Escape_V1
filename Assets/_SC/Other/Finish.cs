using System.Globalization;
using TMPro;
using UnityEngine;

namespace _SC.Other
{
    public class Finish : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        
        void Start()
        {
            float score =  (PlayerPrefs.GetInt("Lvl") * 100 + PlayerPrefs.GetFloat("LvlNext")) - 100;
            scoreText.text = ((int)score).ToString(CultureInfo.InvariantCulture);
        }
    }
}
