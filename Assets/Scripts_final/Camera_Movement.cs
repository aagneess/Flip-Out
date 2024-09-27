using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform Player;
    private float xlimit;
    public bool canFollow = true; //check if camera can follow player

    private GameObject TutorialCanvas;
    private string Canvasname = "Tutorial Messages";
    private bool checkposition = false;
    private float delayHideTutorial = 3f;

    //x limit för spelaran vad är positionen på kameran när den början 
    //lägg den på efter camera.x 
    // Start is called before the first frame update

    void Start()
    {
        xlimit = transform.position.x;
        Debug.Log(canFollow);

        TutorialCanvas = GameObject.Find(Canvasname);

    }

    // Update is called once per frame
    void Update()
    {
        if (canFollow)
        {
            Vector3 stillposition = transform.position;

            Vector3 Cameraposition = transform.position;
            Cameraposition.x = Player.position.x;
            Cameraposition.x = Mathf.Max(Cameraposition.x, -xlimit); //takes  the largest value
            transform.position = Cameraposition;

            Invoke("Cameracheck", delayHideTutorial);

            //if the camera is not in stillposition and the checkposition is true hide tutorial
            if (Cameraposition != stillposition && checkposition)
            {
                TutorialCanvas.SetActive(false);
            }

            
        }
    }

    private void Cameracheck()
    {
        checkposition = true;
      //  Debug.Log(checkposition);
    }

    // Detect when the camera enters the stopCamera tag
    public void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the camera collided with the empty GameObject (tagged "StopCamera")
        if (collider.gameObject.CompareTag("stopCamera"))
        {
            canFollow = false; // Stop the camera from following the player
            Debug.Log("be false:"+ canFollow);
        }

    }
}
 

