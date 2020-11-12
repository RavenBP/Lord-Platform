using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    static int scoreVal = 0;

    // Start is called before the first frame update
    void Start()
    {
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
