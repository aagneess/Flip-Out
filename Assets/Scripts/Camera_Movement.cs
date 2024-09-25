using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform Player;
    private float xlimit;

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
        Vector3 Cameraposition = transform.position;

        Cameraposition.x = Player.position.x;

        Cameraposition.x = Mathf.Max(Cameraposition.x, -xlimit); //takes  the largest value

        transform.position = Cameraposition;
    }
}
