using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Transform startPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(1,0,0);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("fh");
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.position= startPoint.position;
        }
    }

}
