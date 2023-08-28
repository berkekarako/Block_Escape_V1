using UnityEngine;
using System.IO;

namespace _SC
{
    public class DataL : MonoBehaviour
    {
        public class PlayerData
        {
            public int Lvl;
            public float NextLvl;
            public int MaxLvl;
            public float MaxNextLvl;
        }
        
        public void LoadData(int lvl, float nextLvl)
        {
            PlayerData playerData = new PlayerData
            {
                Lvl = lvl,
                NextLvl = nextLvl
            };

            string loadData = JsonUtility.ToJson(playerData);
            File.WriteAllText(Application.dataPath + "/AA.json", loadData);
        }

        public PlayerData GetData()
        {
            string path = Application.dataPath + "/AA.json";
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            return playerData;
        }

        public void LoadPlayerLvl(int lvl, float nextLvl)
        {
            PlayerData data = GetData();
            PlayerData playerData = new PlayerData();

            if (lvl > data.MaxLvl)
            {
                playerData = new PlayerData
                {
                    Lvl = lvl,
                    NextLvl = nextLvl,
                    MaxLvl = lvl,
                    MaxNextLvl = nextLvl
                };
            }
            else if(lvl == data.MaxLvl && nextLvl > data.MaxNextLvl)
            {
                playerData = new PlayerData
                {
                    Lvl = lvl,
                    NextLvl = nextLvl,
                    MaxLvl = lvl,
                    MaxNextLvl = nextLvl
                };
            }
            else
            {
                playerData = new PlayerData
                {
                    Lvl = lvl,
                    NextLvl = nextLvl
                };
            }
                
            string loadData = JsonUtility.ToJson(playerData);
            File.WriteAllText(Application.dataPath + "/AA.json", loadData);
        }
    }
}
