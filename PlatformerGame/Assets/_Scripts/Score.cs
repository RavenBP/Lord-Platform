// File Name: Score.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/29/20
// Description: Script that controls HUD element for score.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    public static int scoreVal = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Reset score
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            scoreVal = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreVal;
    }

    public int GetScore()
    {
        return scoreVal;
    }
}
