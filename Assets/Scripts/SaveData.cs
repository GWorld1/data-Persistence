using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveData : MonoBehaviour
{
    public static SaveData save;
    public int finalscore ;
    public int highscore = 0;
    public string Name ="";
    public string UserName;

    public string bestScore;


    // Start is called before the first frame update
    private void Awake()
    {

        if (save != null)
        {
            Destroy(gameObject);
            return;
        }
       
        save = this;
        DontDestroyOnLoad(gameObject);
        LoadUserData();
    }
    private void Update()
    {
        bestScore = Name + ":BestScore:" + highscore ;
    }

    class Save
    {
     
        public int finalscoreS;
        public string UserNameS;
        public string bestScoreS;
    }
  public void SaveUserData()
    {
        Save userData = new Save();
        userData.finalscoreS = highscore;
        userData.UserNameS = Name;
        userData.bestScoreS = bestScore;
        string json = JsonUtility.ToJson(userData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Save userData = JsonUtility.FromJson<Save>(json);
            highscore = userData.finalscoreS;
            Name = userData.UserNameS;
            bestScore = userData.bestScoreS;
        }
    }
    }
