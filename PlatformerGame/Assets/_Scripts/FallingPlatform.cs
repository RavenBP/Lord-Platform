// File Name: FallingPlatform.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/29/20
// Description: Script that controls "TogglePlatform" prefab. This platform will enable and disable itself upon contact with the player.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    float toggleDelay;

    [Header("Audio")]
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;

    bool canContinue;

    // Start is called before the first frame update
    void Start()
    {
        canContinue = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // Platform is making contact with player
        {
            if (canContinue == true) // Platform isn't performing triggered action
            {
                StartCoroutine(Disable());
            }
        }
    }

    IEnumerator Disable()
    {
        canContinue = false; // Ensure coroutine will not be called multiple times
        yield return new WaitForSeconds(toggleDelay);

        GetComponent<BoxCollider2D>().enabled = false; // Disable collision
        GetComponent<SpriteRenderer>().color = new Vector4(1, 0, 0, 1); // Change colour

        // Play sound
        audioSource.clip = audioClips[0];
        audioSource.Play();

        yield return new WaitForSeconds(toggleDelay);

        GetComponent<BoxCollider2D>().enabled = true; // Enable collision
        GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 0, 1); // Chage colour

        // Play sound
        audioSource.clip = audioClips[1];
        audioSource.Play();

        canContinue = true; // Now that platform has been re-enabled, it can now be triggered again
    }
}
