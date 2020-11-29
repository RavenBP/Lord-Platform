// File Name: FallingPlatform.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/28/20
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
        if (collision.collider.CompareTag("Player"))
        {
            if (canContinue == true)
            {
                StartCoroutine(Disable());
            }
        }
    }

    IEnumerator Disable()
    {
        canContinue = false;
        yield return new WaitForSeconds(toggleDelay);

        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Vector4(1, 0, 0, 1);

        audioSource.clip = audioClips[0];
        audioSource.Play();

        yield return new WaitForSeconds(toggleDelay);

        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 0, 1);

        audioSource.clip = audioClips[1];
        audioSource.Play();

        canContinue = true;
        Debug.Log("Disabled!");
    }

    //IEnumerator Reset()
    //{
    //    canContinue = false;
    //    yield return new WaitForSeconds(2);

    //    GetComponent<BoxCollider2D>().enabled = true;
    //    GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 0, 1);
    //    canContinue = true;

    //    Debug.Log("Re-enabled!");
    //}
}
