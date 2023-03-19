using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 10f;
    public GameObject playerOwner;
    private bool returning = false;
    private Vector3 originalPosition;
    private Rigidbody rb;
    private Vector3 startPosition; 
    

    [Header("Bounce")] 
    [HideInInspector] public bool activeBounce;
    public float bounceSpeed = 7f;
    [Range(0.1f, 0.9f)] [Tooltip("Ex : si tu met 0.9 ça fera 10% de perte donc si tu veux faire 90% de pert tu met 0.1")]
    public float percentagePertVelocity = 0.9f;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        transform.Rotate(-90f,0, 0);
        rb.velocity = transform.forward * speed;
        rb.angularVelocity = new Vector3(0, 0, 20);
    }

    void FixedUpdate()
    {
        if (!returning)
        {
            // Move the boomerang forward
            // transform.Translate(Vector3.forward * Time.deltaTime * speed);
            
            // If the boomerang has reached its maximum distance, start returning
            if (Vector3.Distance(playerOwner.transform.position, transform.position) > maxDistance)
            {
                returning = true;
            }
        }
        else
        {
            var position = playerOwner.transform.position;
            
            // Calculate the direction to the player
            Vector3 direction = (position - transform.position).normalized;
            
            // Rotate the boomerang towards the player
            transform.rotation = Quaternion.LookRotation(direction);
            
            
            // Move the boomerang towards the player
            // transform.Translate(Vector3.forward * Time.deltaTime * speed);
            rb.velocity = (position - transform.position).normalized * speed;
            
            // If the boomerang is close enough to the player, reset its position and rotation
            if (Vector3.Distance(playerOwner.transform.position, this.transform.position) < 0.1f)
            {
                transform.position = startPosition;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                returning = false;
            }
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
    
    // Fonction pour calculer une position sur une courbe de Bezier
    private Vector3 BezierCurve(Vector3 startPoint, Vector3 midPoint, Vector3 endPoint, float t)
    {
        return ((1 - t) * (1 - t) * startPoint) + (2 * (1 - t) * t * midPoint) + (t * t * endPoint);
    }
}
