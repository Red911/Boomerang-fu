using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration _playerConfiguration;
    private PlayerMovement _playerMovement;
    [SerializeField] private MeshRenderer playerMesh;
    private int _whichTeam;
    private PlayerControls _controls;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _controls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        _playerConfiguration = pc;
        _playerMovement._playerID = pc.PlayerIndex++;
        playerMesh.material = pc.PlayerMaterial;
        _whichTeam = pc.PlayerTeam;
        _playerConfiguration.Input.onActionTriggered += InputOnActionTriggered;
    }

    private void InputOnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.name == _controls.Player.Movement.name)
        {
            OnMove(obj);
        }
        else if (obj.action.name == _controls.Player.Fire.name)
        {
            OnFire(obj);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_playerMovement != null)
        {
            _playerMovement.SetInputVector(context.ReadValue<Vector2>());
        }
    }
    
    public void OnFire(InputAction.CallbackContext launch)
    {
        if (_playerMovement != null)
        {
            _playerMovement.LaunchProjectile();
        }
    }
}
