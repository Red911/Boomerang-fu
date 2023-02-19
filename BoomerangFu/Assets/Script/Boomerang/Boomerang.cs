using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    public float returnDistance = 5.0f;
    public GameObject playerOwner;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.angularVelocity = new Vector3(0, 0, 20);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, playerOwner.transform.position) > returnDistance)
        {
            rb.velocity = (playerOwner.transform.position - transform.position).normalized * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
