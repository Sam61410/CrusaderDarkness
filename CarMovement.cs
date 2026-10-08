using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;

public class CarMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5;
    public float maxSpeed = 30;
    public float minSpeed = 0;

    //Vector3 acceleration = new Vector3(forward);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            speed -= Time.deltaTime;
        }
        else
        {
            speed = 5;
        }
        if (Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (rb.linearVelocity.magnitude > maxSpeed) return;
            else
            {
                rb.AddForce(transform.forward * speed);
            }
        }
        if (Input.GetKey(KeyCode.A) && rb.linearVelocity.magnitude >= 0)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * -2f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (rb.linearVelocity.magnitude < minSpeed) return;
            else
            {
                rb.AddForce(-transform.forward * speed);
            }
        }
        if (Input.GetKey(KeyCode.D) && rb.linearVelocity.magnitude >= 0)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * 2f));
        }
    }
}
