using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControl playerControl;

    private static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance != null && _instance != this) Destroy(this.gameObject); 
        else
        {
            _instance = this;
        }
        playerControl = new PlayerControl();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControl.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControl.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        return playerControl.Player.Jump.triggered;
    }
}
