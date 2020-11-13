using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    [SerializeField]
    GameObject heart;

    private void OnTriggerEnter2D(Collider2D collision) // Increment player lives upon pickup
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerController.playerLives < 3) // Player does not have maximum hearts
            {
                PlayerController.playerLives++;
                Destroy(heart);
            }
            else
            {
                Debug.Log("Player has maximum lives");
                // Play a sound?
            }
        }
    }
}
