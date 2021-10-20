using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody rb;

    Vector3 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * 0.1f;
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

        transform.LookAt(transform.position + direction * 10);
    }

}
