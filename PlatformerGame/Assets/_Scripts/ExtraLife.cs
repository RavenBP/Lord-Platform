// File Name: ExtraLife.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/29/20
// Description: Script for extra life pickup.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    [SerializeField]
    GameObject heart;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Disable()
    {
        //Debug.Log("Heart Disabled");
        this.GetComponent<SpriteRenderer>().color = Color.clear;
        this.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(1); // Short wait time to make sure audio is played through

        //Debug.Log("Heart Destroyed");
        Destroy(heart);
    }

    private void OnTriggerEnter2D(Collider2D collision) // Increment player lives upon pickup
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerController.playerLives < 3) // Player does not have maximum hearts
            {
                PlayerController.playerLives++;
                audioSource.Play();
                StartCoroutine(Disable());
            }
        }
    }
}
