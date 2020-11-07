using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D;
    [SerializeField]
    float speed = 5.0f;

    float xSeperation = 0.3f;

    Vector2 movementVector;
    Vector2 screenTouchPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        screenTouchPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.touchCount > 0)
        {
            if (screenTouchPosition.x > xSeperation)
            {
                movementVector = new Vector2(1.0f, 0.0f) * speed * Time.deltaTime;
                rigidbody2D.transform.Translate(movementVector);
            }
            else if (screenTouchPosition.x < xSeperation)
            {
                movementVector = new Vector2(1.0f, 0.0f) * -speed * Time.deltaTime;
                rigidbody2D.transform.Translate(movementVector);
            }
        }
    }
}
