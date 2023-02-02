using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject projectilePrefab;
    private CharacterController _controller;
    private PlayerControls _controls;
    
    public float speed = 6;
    public float turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    private Vector3 _inputVector;

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    


    // public void SetInputVector(Vector3 direction)
    // {
    //     _inputVector = direction;
    // }
    
    public void OnMove(InputAction.CallbackContext direction)
    {
        _inputVector = direction.ReadValue<Vector3>();
    }
    
    public void OnFire(InputAction.CallbackContext launch)
    {
        if (launch.performed )
        {
            LaunchProjectile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(_inputVector.x, 0f,_inputVector.z).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            _controller.Move(direction * speed * Time.deltaTime);
        }
    }
    
    void LaunchProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
    }
}
