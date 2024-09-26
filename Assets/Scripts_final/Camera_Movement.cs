using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform Player;
    private float xlimit;
    private bool canFollow = true; //check if camera can follow player

    //x limit för spelaran vad är positionen på kameran när den början 
    //lägg den på efter camera.x 
    // Start is called before the first frame update

    void Start()
    {
        xlimit = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (canFollow)
        {
            Vector3 Cameraposition = transform.position;
            Cameraposition.x = Player.position.x;
            Cameraposition.x = Mathf.Max(Cameraposition.x, -xlimit); //takes  the largest value
            transform.position = Cameraposition;
        }

    }
    // Detect when the camera enters a trigger
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the camera collided with the empty GameObject (tagged "StopCamera")
        if (collider.gameObject.CompareTag("stopCamera"))
        {
            canFollow = false; // Stop the camera from following the player

        }

    }
}
 

