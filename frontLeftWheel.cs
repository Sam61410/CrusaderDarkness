using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class frontLeftWheel : MonoBehaviour
{
    public GameObject frontLeftWheelPrefab;
    public Quaternion targetRotation;
    public Quaternion negativeTargetRotation;
    private Rigidbody rb;
    public float duration;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator RotateObject(GameObject obj, Quaternion targetRot, float duration)
    {
        Quaternion startRot = obj.transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            obj.transform.rotation = Quaternion.Lerp(startRot, targetRot, elapsedTime / duration);
            yield return null;
        }
    }
    
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            rb.AddForce(Vector3.forward);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            rb.AddForce(Vector3.back);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            StartCoroutine(RotateObject(frontLeftWheelPrefab, targetRotation, duration));
        }
        if (Keyboard.current.dKey.isPressed)
        {
            StartCoroutine(RotateObject(frontLeftWheelPrefab, negativeTargetRotation, duration));
        }
    }
}
