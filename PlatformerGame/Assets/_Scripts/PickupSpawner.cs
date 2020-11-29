// File Name: PickupSpawner.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/29/20
// Description: Script that controls which pickup to spawn at a specified location.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject coin;
    [SerializeField]
    GameObject extraLife;

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, 100);

        // Spawn random pickup
        if (randomNum <= 70) // Spawn coin
        {
            Instantiate(coin, transform.position, transform.rotation);
            //Debug.Log("Coin spawned");
        }
        else if (randomNum >= 71 && randomNum <= 90) // Spawn extra life
        {
            Instantiate(extraLife, transform.position, transform.rotation);
            //Debug.Log("Life spawned");
        }
        else // Spawn nothing
        {
            //Debug.Log("Nothing was spawned");
        }
    }
}
