using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMainMenu : MonoBehaviour
{

   public string scene;
    public ScoreData score;

   public void toMainMenu()
    {
        score.writeToLeaderboard();
        

        SceneManager.LoadScene(scene);
        //Time.timeScale = 1f;
        //AudioListener.volume = 1;
    }
}
