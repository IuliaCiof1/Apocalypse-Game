using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public string scene;
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public GameObject graphicsOption;
    public GameObject audioOption;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        graphicsOption.SetActive(false);
        audioOption.SetActive(false);

        Time.timeScale = 1f; //unfreez time
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseScreen.SetActive(true);
        Time.timeScale = 0f; //freez time
        GameIsPaused = true;
    }
    //Main screen
    public void Options()
    {
        optionsScreen.SetActive(true);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
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
