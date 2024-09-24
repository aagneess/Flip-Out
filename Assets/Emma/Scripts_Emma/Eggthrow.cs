using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggthrow : MonoBehaviour
{
    [SerializeField] private GameObject _egg;
    [SerializeField] private Transform ThrowPointStart;
    [SerializeField] private Transform ThrowPointEnd;

    private Vector3 centerPoint = new();

    [SerializeField] float startTime;

    [SerializeField] private float ThrowRate = 1f;

    [SerializeField] private float throwJourney = 1f;

    void Update()
    {
        Trowing();      
    }

    private void Trowing()
    {
        centerPoint = (ThrowPointStart.position + ThrowPointEnd.position) * 0.5f;
        
        Vector3 relativeStart = ThrowPointStart.position - centerPoint;
        Vector3 relativeEnd = ThrowPointEnd.position - centerPoint;



        //FireRate & Input
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > throwJourney)
        {
            startTime = Time.time;

            float fracTime = (Time.time - startTime) / throwJourney;

            GameObject _throwInstance  = Instantiate(_egg);
            transform.position = Vector3.Slerp(ThrowPointStart.position, ThrowPointEnd.position, fracTime);

            throwJourney = Time.time + ThrowRate;
            

        }
    }
}
