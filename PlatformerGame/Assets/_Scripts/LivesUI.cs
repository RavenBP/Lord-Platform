using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            case 0:
                heart1.color = new Color(0, 0, 0, 255);
                break;
            case 1:
                heart1.color = new Color(255, 255, 255, 255);
                heart2.color = new Color(0, 0, 0, 255);
                break;
            case 2:
                heart1.color = new Color(255, 255, 255, 255);
                heart2.color = new Color(255, 255, 255, 255);
                heart3.color = new Color(0, 0, 0, 255);
                break;
            case 3:
                heart1.color = new Color(255, 255, 255, 255);
                heart2.color = new Color(255, 255, 255, 255);
                heart3.color = new Color(255, 255, 255, 255);
                break;
        }
    }
}
