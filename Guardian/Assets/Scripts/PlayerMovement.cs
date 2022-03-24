using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 5f;

    Rigidbody rb;
    Vector3 moveInput;
    Vector3 playerMovement;
    PlayerAnimation playerAnimation;
    
    bool isMoving;
    bool isTurning;
    float moveYPos;
    float moveZPos;
    float moveRotation;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    
    void Update()
    {
        Move();
        TurningCheck();
    }


    void Move()
    {
       if(isTurning && moveInput.y == 0) { return; }
        
        moveZPos = playerAnimation.velocity * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(0f, 0f, moveZPos));
    }


    void OnMove(InputValue value)
    {   
        moveInput = value.Get<Vector2>();
    }


    void TurningCheck()
    {
        moveRotation = moveInput.x * turnSpeed * Time.deltaTime;

        if(moveInput.x != 0)
        {
            isTurning = true;
            transform.Rotate(0f, moveRotation, 0f, Space.Self);
        }
        else if(playerAnimation.velocity == 0 && moveInput.y == 0)
        {
            isTurning = false;
        }
    }
}
