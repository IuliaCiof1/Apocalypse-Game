using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string scene;
    public GameObject optionsScreen;
    public GameObject graphicsOption;
    public GameObject audioOption;
    public GameObject leaderboardScreen;

    //Main screen
    public void Play()
    {
        SceneManager.LoadScene(scene);   
    }

    public void Options()
    {
        optionsScreen.SetActive(true);
    }

    public void Leaderboard()
    {
        leaderboardScreen.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void LeaderboardBack()
    {
        leaderboardScreen.SetActive(false);
    }
    //OPtions screen

    public void OptionsBack()
    {
        optionsScreen.SetActive(false);
    }

    public void EnterGraphics()
    {
        graphicsOption.SetActive(true);
    }

    public void GraphicsBack()
    {
        graphicsOption.SetActive(false);
    }

    public void EnterAudio()
    {
        audioOption.SetActive(true);
    }

    public void AudioBack()
    {
        audioOption.SetActive(false);
    }
}
