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

    [Header("Bounce")] 
    [HideInInspector] public bool activeBounce;
    public float bounceSpeed = 7f;
    [Range(0.1f, 0.9f)] [Tooltip("Ex : si tu met 0.9 ça fera 10% de perte donc si tu veux faire 90% de pert tu met 0.1")]
    public float percentagePertVelocity = 0.9f;
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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerBehaviour_Test>().isDead = true;
            Destroy(this.gameObject);
        }
        else if(col.gameObject.CompareTag("Wall"))
        {
            if (activeBounce)
            {
                Vector3 normal = col.contacts[0].normal;
                var direction = Vector3.Reflect(transform.forward, normal);
                rb.AddForce(direction * bounceSpeed, ForceMode.Impulse);
                rb.velocity *= percentagePertVelocity;
            }
            else
            {
                /*
                // Calculate the force of the collision
                float collisionForce = col.impulse.magnitude;
                
                // Apply a force to the projectile in the opposite direction of the collision
                rb.AddForce(-col.impulse.normalized * collisionForce, ForceMode.VelocityChange);
                */
                
                // If shouldBounce is false, stick the projectile to the wall
                rb.constraints = RigidbodyConstraints.FreezeAll;
                
            }
            
        }
    }
}
