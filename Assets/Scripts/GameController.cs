using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject player;
    private GameObject[] pickups;
    public TextMeshProUGUI distanceText;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        pickups = GameObject.FindGameObjectsWithTag("PickUp");
    }

    void Update()
    {
        float closestDistance = float.MaxValue;
        GameObject closestPickup = null;

        for (int i = 0; i < pickups.Length; i++)
        {
            if (pickups[i].activeInHierarchy)
            {
                float distance = Vector3.Distance(player.transform.position, pickups[i].transform.position);
                if (distance < closestDistance)
                {
                    if (closestPickup != null)
                    {
                        // Set previous closest pickup color back to white
                        closestPickup.GetComponent<Renderer>().material.color = Color.white;
                    }

                    closestDistance = distance;
                    closestPickup = pickups[i];

                    // Set new closest pickup color to blue
                    closestPickup.GetComponent<Renderer>().material.color = Color.blue;
                }
                else
                {
                    // Set other pickup colors back to white
                    pickups[i].GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }

        if (closestPickup != null)
        {
            distanceText.text = "Distance to closest pickup: " + closestDistance.ToString("0.00");

            // Draw line from player to closest pickup
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, closestPickup.transform.position);
        }
    }
}
