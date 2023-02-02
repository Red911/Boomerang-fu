using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
   
    private PlayerControls _controls;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _controls = new PlayerControls();
    }

    // private void InputOnActionTriggered(InputAction.CallbackContext ctx)
    // {
    //     if (ctx.action.name == _controls.Player.Movement.name)
    //     {
    //         OnMove(ctx);
    //     }
    //     
    // }

    // private void OnMove(InputAction.CallbackContext ctx)
    // {
    //     if (_playerMovement != null) 
    //     {
    //         _playerMovement.SetInputVector(ctx.ReadValue<Vector3>());
    //     }
    // }
}
