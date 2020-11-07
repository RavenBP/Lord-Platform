using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject mainPanel;
    [SerializeField]
    GameObject creditsPanel;
    [SerializeField]
    GameObject instructionsPanel;

    bool creditsPanelActive = false;
    bool instructionsPanelActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
