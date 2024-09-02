using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public PlayerInput myPlayerInput;
    private InputAction move;
    private bool isMoving;
    private bool shot;
    public GameManager manager;

    public Rigidbody2D tank;
    public int moveSpeed = (int) 5f;
    public int moveDirection = (int) 5f;

    void Start()
    {
        myPlayerInput.currentActionMap.Enable();
        move = myPlayerInput.currentActionMap.FindAction("Move");

        move.started += Move_started;
        move.canceled += Move_canceled;

    }


    private void Move_canceled(InputAction.CallbackContext obj)
    {
        isMoving = false;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        isMoving = true;

       
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            //Moving the paddle
            tank.GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveSpeed * moveDirection);
        }
        else
        {
            //stop the paddle
            tank.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }





    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            moveDirection = (int)move.ReadValue<float>();
        }
    }
}
