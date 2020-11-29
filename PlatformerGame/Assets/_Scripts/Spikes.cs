// File Name: Spikes.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/28/20
// Description: Script that controls behaviour for spike hazard

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController.playerLives--;
            audioSource.Play();
        }
    }
}
