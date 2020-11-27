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
        Debug.Log("Coin disabled");
        this.GetComponent<SpriteRenderer>().color = Color.clear;
        this.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(1);

        Debug.Log("Coin Destroyed");
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
