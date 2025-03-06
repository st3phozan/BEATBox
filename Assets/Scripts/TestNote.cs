using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNote : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 randomDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomDirection = GetRandomForward(transform.forward, 5f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float forceMagnitude = 4f; // Adjust as needed
        rb.AddForce(randomDirection * forceMagnitude, ForceMode.Force);
    }
    Vector3 GetRandomForward(Vector3 forward, float maxAngle)
    {
        float randomAngle = Random.Range(-maxAngle, maxAngle); // Random angle from left to right
        return Quaternion.AngleAxis(randomAngle, Vector3.up) * forward;
    }
    void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
