using TMPro;
using UnityEngine;

namespace _SC.Other
{
    public class Finish : MonoBehaviour
    {
        public TextMeshProUGUI score;
        
        void Start()
        {
            score.text = PlayerPrefs.GetInt("Lvl").ToString();
        }
    }
}
