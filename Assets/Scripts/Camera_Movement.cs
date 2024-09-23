using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 Cameraposition = transform.position;

        Cameraposition.x = Player.position.x;

        transform.position = Cameraposition;
    }
}
