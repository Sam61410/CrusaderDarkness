using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    public int speed = 5;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 1);
        }
    }
}

