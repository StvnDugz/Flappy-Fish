using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int scoreAmount;      // the score amount
    public Text scoreText;              // the score text
    public GameObject winText;          // the level complete text

    void Start()
    {
        // Setting up the references
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        // convert the score amount to a string
        scoreText.text = "SCORE: " + scoreAmount.ToString();

        if (scoreAmount >= 7)
        {
            //display the level complete text
            winText.SetActive(true);
            GameOverManager.instance.Win();
        }
    }
}