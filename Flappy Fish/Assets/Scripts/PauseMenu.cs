using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private AudioSource audioSource;            // Reference to the audio source  
    public GameObject pauseMenuUI;              // Reference to the  pause menu game object
    public static bool IsPaused = false;        // Whether the game is pauded
    public GameObject text;
    public GameObject text2;


    void Start()
    {
        // Setting up the references
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        // If the escape button is pressed
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        */


        // if the game is not over and the input is pressed
        if (GameOverManager.instance.gameOver == false && Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        text.SetActive(true);
        text2.SetActive(true);
        Cursor.visible = false;
}

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        text.SetActive(false);
        text2.SetActive(false);
        Cursor.visible = true;  
    }

public void Restart()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
