using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 moveValue;
    public float speed ;

    void OnMove(InputValue movementValue)
    {
        moveValue = movementValue.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed);
    }
}
