using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject projectilePrefab;
    private CharacterController _controller;

    public float speed = 6;
    public float turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    private Vector2 _inputVector;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    
    public void SetInputVector(Vector2 direction)
    {
        _inputVector = direction;
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(_inputVector.x, 0f,_inputVector.y).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            _controller.Move(direction * speed * Time.deltaTime);
        }
    }
    
    public void LaunchProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
    }
}
