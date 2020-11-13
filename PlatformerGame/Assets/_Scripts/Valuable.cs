using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour
{
    [SerializeField]
    GameObject coin;
    [SerializeField]
    int scoreValue = 5;

    int GetScoreValue()
    {
        return scoreValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Player touched a coin it was worth: " + scoreValue);
            Score.scoreVal += scoreValue;
            Destroy(coin);
        }
    }
}
