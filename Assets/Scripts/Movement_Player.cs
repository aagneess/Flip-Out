using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    public float Speed = 1f;
    public float acceleration = 1f;
    private Rigidbody2D rb2D;

    //Change to private after testing is done
    //private float speed = 1f; (test what speed is best)

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LaneMovement();

        //g�ra s� det g�r snabbare och snabbare ju mer tiden g�r. 
        Speed += acceleration * Time.deltaTime;
        Debug.Log("speed:" + Speed);

    }

    public void LaneMovement()
    {

        //speed of player 
        rb2D.velocity = new Vector2(Speed, rb2D.velocity.y);

        float xAxis = transform.position.x; // x axis
        float yAxis = transform.position.y; //y axis

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            yAxis -= 1;
            yAxis = Mathf.Clamp(yAxis, 0, 1);
            // Camera.main.transform.position = new Vector3(xAxis, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            yAxis += 1;
            yAxis = Mathf.Clamp(yAxis, 0, 1);
            //  Camera.main.transform.position= new Vector3(xAxis, 0, 0);

        }

        //update movement
        transform.position = new Vector2(xAxis, yAxis);
    }
}
