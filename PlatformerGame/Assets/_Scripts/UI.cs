// File Name: UI.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/28/20
// Description: Script that holds most functionality for UI elements within the game. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject mainPanel;
    [SerializeField]
    GameObject secondaryPanel;
    [SerializeField]
    GameObject instructionsPanel;

    [SerializeField]
    GameObject leftPanel;
    [SerializeField]
    GameObject middlePanel;
    [SerializeField]
    GameObject rightPanel;

    bool creditsPanelActive = false;
    bool instructionsPanelActive = false;

    bool gamePaused = false;



    // Start is called before the first frame update
    void Start()
    {
        if (leftPanel && middlePanel && rightPanel)
        {
            leftPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, Screen.height);
            middlePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, Screen.height);
            rightPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, Screen.height / 2);
        }

        // Display appropriate panel for finished game
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (PlayerController.completedLevel == true) // Player completed the level
            {
                secondaryPanel.SetActive(true); // "Congratulations"
            }
            else // Player lost all of their lives
            {
                mainPanel.SetActive(true); // "Game Over"
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CreditsPanel()
    {
        if (creditsPanelActive == false)
        {
            mainPanel.SetActive(false);
            secondaryPanel.SetActive(true);
            creditsPanelActive = true;
        }
        else if (creditsPanelActive == true)
        {
            secondaryPanel.SetActive(false);
            creditsPanelActive = false;
            mainPanel.SetActive(true);
        }
    }

    public void InstructionsPanel()
    {
        if (instructionsPanelActive == false)
        {
            mainPanel.SetActive(false);
            instructionsPanel.SetActive(true);
            instructionsPanelActive = true;
        }
        else if (instructionsPanelActive == true)
        {
            instructionsPanel.SetActive(false);
            instructionsPanelActive = false;
            mainPanel.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1; // Ensure time is unpaused if pressed from PausePanel
    }

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            mainPanel.SetActive(false);
            secondaryPanel.SetActive(true);
            gamePaused = true;
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
            secondaryPanel.SetActive(false);
            mainPanel.SetActive(true);
            gamePaused = false;
        }
    }

    ////////////////////////////////////////// DEBUG
    
    public void TriggerGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void IncreaseScore()
    {
        Score.scoreVal += 10;
    }

    public void DecreaseLives()
    {
        PlayerController.playerLives--;
    }
}
