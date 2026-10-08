using UnityEngine;
using System;
using System.Collections;


public class BarrelScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameManager gameManager;
    public Transform startPoint;
    public Vector3 forward;

    public float respawnTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindFirstObjectByType<GameManager>();
        respawnTime = 0;
    }

    void Update()
    {
        respawnTime += Time.deltaTime;
        if (respawnTime > 5)
        {
            Respawn();
            respawnTime = 0f;
        }
        if (gameManager.gameStarted)
        {
            rb.AddForce(forward);
        }
        else return;
    }

    public void Respawn()
    {
        transform.position = startPoint.position;
        rb.AddForce(-forward);
    }
}
