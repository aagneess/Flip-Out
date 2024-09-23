using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggthrow : MonoBehaviour
{
    public GameObject _egg;
    public Transform ThrowPoint;
    
    public float ThrowRate = 1f;
    public float throwIntervall = 1f;

    void Update()
    {
        Trowing();      
    }

    private void Trowing()
    {

        //FireRate & Input
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > throwIntervall)
        {
            GameObject _throwInstance  = Instantiate(_egg, ThrowPoint.position, Quaternion.identity);

            throwIntervall = Time.time + ThrowRate;
            

        }
    }
}
