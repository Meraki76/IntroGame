using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 offset;
    void Start()
    {
        offset = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        
    }
}
