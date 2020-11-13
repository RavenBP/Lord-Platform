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
    GameObject creditsPanel;
    [SerializeField]
    GameObject instructionsPanel;
    [SerializeField]
    Text livesText;

    bool creditsPanelActive = false;
    bool instructionsPanelActive = false;

    bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (livesText)
        {
            livesText.text = "Lives: " + PlayerController.playerLives;
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
            creditsPanel.SetActive(true);
            creditsPanelActive = true;
        }
        else if (creditsPanelActive == true)
        {
            creditsPanel.SetActive(false);
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
    }

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
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
