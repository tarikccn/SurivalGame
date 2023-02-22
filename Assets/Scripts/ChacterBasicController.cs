using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class ChacterBasicController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private InputManager inputManager;
    private Transform cameraTransform;
    public GameObject head;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
       //head = head.gameObject.GetComponent<GameObject>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 6f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) playerSpeed = 2f;


        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        head.transform.rotation = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);
        move = head.transform.forward * move.z + cameraTransform.right * move.x;

        //controller.transform.rotation = Quaternion.Euler(cameraTransform.forward);

        move.y = 0;
        
        controller.Move(move * Time.deltaTime * playerSpeed);
/*
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
*/
        // Changes the height position of the player..
        if (inputManager.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
