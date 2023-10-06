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
    public TextMeshProUGUI playerPosition;
    public TextMeshProUGUI playerVelocity;
    public Vector2 moveValue;

    private Vector3 lastPosition;
    private Vector3 currentVelocity;
    private Vector3 currentPosition;


    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
        lastPosition = transform.position;
    }

    void OnMove(InputValue movementValue)
    {
        moveValue = movementValue.Get<Vector2>();
    }


    void Update(){
        playerPosition.text = "Position: " + currentPosition.ToString("0.00");
        playerVelocity.text = "Velocity: " + currentVelocity.ToString("0.00") + ", Speed: " + currentVelocity.magnitude.ToString("0.00");
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
        currentVelocity = (currentPosition - lastPosition) / Time.deltaTime;
        lastPosition = currentPosition;

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

