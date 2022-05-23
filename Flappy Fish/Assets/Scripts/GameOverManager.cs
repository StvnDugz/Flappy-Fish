using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;     // reference to the instance
    public GameObject gameOverText;             // reference to the gameover text
    public GameObject restartText;              // reference to the restart text
    public GameObject player;                   // reference to the player game object
    ScoreManager ScoreManager;                  // refernce to the ScoreManager script
    public bool gameOver = false;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }


    void Start()
    {
        // set the score amount to zero
        ScoreManager.scoreAmount = 0;
    }


    void Update()
    {
        // If the player has run out of health
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            // reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // if the player dies
    public void Die()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        restartText.SetActive(true);
    }

    // if the player wins
    public void Win()
    {
        gameOver = true;
        restartText.SetActive(true);
        player.SetActive(false);
    }
}
