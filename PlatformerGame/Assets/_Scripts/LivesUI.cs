// File Name: LivesUI.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/29/20
// Description: Script that controls HUD element for lives.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesUI : MonoBehaviour
{
    [SerializeField]
    Image heart1;
    [SerializeField]
    Image heart2;
    [SerializeField]
    Image heart3;

    // Update is called once per frame
    void Update()
    {
        switch (PlayerController.playerLives) // Update LivesUI 
        {
            case -1: // Player is out of lives
                SceneManager.LoadScene("GameOverScene");
                break;
            case 0: // Player has no lives remaining
                heart1.color = new Color(0, 0, 0, 255);
                break;
            case 1: // Player has 1 life
                heart1.color = new Color(255, 255, 255, 255);
                heart2.color = new Color(0, 0, 0, 255);
                break;
            case 2: // Player has 2 lives
                heart1.color = new Color(255, 255, 255, 255);
                heart2.color = new Color(255, 255, 255, 255);
                heart3.color = new Color(0, 0, 0, 255);
                break;
            case 3: // Player has 3 lives
                heart1.color = new Color(255, 255, 255, 255);
                heart2.color = new Color(255, 255, 255, 255);
                heart3.color = new Color(255, 255, 255, 255);
                break;
        }
    }
}
