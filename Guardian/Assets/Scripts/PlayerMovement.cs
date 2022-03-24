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
    }


    void Move()
    {
        moveRotation = moveInput.x * turnSpeed * Time.deltaTime;
        moveZPos = playerAnimation.velocity * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(0f, 0f, moveZPos));

        transform.Rotate(0f, moveRotation, 0f, Space.Self);
    }


    void OnMove(InputValue value)
    {   
        moveInput = value.Get<Vector2>();
    }

}
