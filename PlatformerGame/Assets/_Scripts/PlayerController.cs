using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D;
    [SerializeField]
    float speed = 5.0f;

    Vector2 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = new Vector2(Input.GetAxis("Horizontal"), 0.0f) * speed * Time.deltaTime;

        rigidbody2D.transform.Translate(movementVector);
    }
}
