// File Name: Valuable.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/29/20
// Description: Script for coin pickup.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour
{
    [SerializeField]
    GameObject coin;
    [SerializeField]
    int scoreValue = 5;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    int GetScoreValue()
    {
        return scoreValue;
    }

    IEnumerator Disable()
    {
        //Debug.Log("Coin disabled");
        this.GetComponent<SpriteRenderer>().color = Color.clear;
        this.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(1); // Short wait time to make sure audio is played through

        //Debug.Log("Coin Destroyed");
        Destroy(coin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Score.scoreVal += scoreValue;
            audioSource.Play();
            StartCoroutine(Disable());
        }
    }
}
