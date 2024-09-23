using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggthrow : MonoBehaviour
{
    public GameObject _eggs;
    public Transform ThrowPoint;
    GameObject _throwInstance;
    public float fireRate = 1f;
    public float fireTime = 1f;

    void Update()
    {
        Trowing();      
    }

    private void Trowing()
    {

        //FireRate & Input
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > fireTime)
        {
            GameObject _throwInstance  = Instantiate(_eggs, ThrowPoint.position, Quaternion.identity);
            
            fireTime = Time.time + fireRate;
            
            //Instantiate(_eggs, this.transform.position + new Vector3(0, 0, 0), transform.rotation);

        }
    }
}
