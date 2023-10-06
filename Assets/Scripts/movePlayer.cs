using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private int count;
    private int numPickups = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public Vector2 moveValue;


    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        moveValue = movementValue.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() {
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups) {
            winText.text = "You Win!";
        }
    }
}

