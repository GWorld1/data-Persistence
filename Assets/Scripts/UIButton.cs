using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UIButton : MonoBehaviour
{

    public TMP_InputField inputField;
    public TextMeshProUGUI bestScore;
    private string Name;
    private int score;
    // Start is called before the first frame update
  

    private void Update()
    {

        Name = SaveData.save.UserName;
        score = SaveData.save.finalscore;
        bestScore.text = SaveData.save.bestScore;
    }
    public void startgame()
    {

        SceneManager.LoadScene(1);
    }
    public void Quitgame()
    {
        
        Application.Quit();
        Debug.Log("exit");
    }
    public void UserName()
    {
        SaveData.save.UserName = inputField.text;
        SaveData.save.finalscore = 0;
      
      
    }
    public void Save()
    {
        Debug.Log("Saved");
        SaveData.save.SaveUserData();
    }
    
}