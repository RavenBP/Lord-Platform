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
            Instantiate(coin, transform);
            Debug.Log("Coin spawned");
        }
        else if (randomNum >= 71 && randomNum <= 90) // Spawn extra life
        {
            Instantiate(extraLife, this.transform);
            Debug.Log("Life spawned");
        }
        else // Spawn nothing
        {
            Debug.Log("Nothing was spawned");
        }
    }
}
