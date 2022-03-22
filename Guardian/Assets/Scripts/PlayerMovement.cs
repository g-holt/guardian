using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 2f;

    Rigidbody rb;
    Vector3 moveInput;
    Vector3 playerMovement;
    
    float moveXPos;
    float moveYPos;
    float moveZPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Move();

    }


    void Move()
    {
        moveXPos = moveInput.x * moveSpeed * Time.deltaTime;
        moveYPos = 
        moveZPos = moveInput.y * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveXPos, 0f, moveZPos));
    }


    void OnMove(InputValue value)
    {   
        moveInput = value.Get<Vector2>();
    }


    void OnJump(InputValue value)
    {
        if(!value.isPressed) { return; }
        
        transform.Translate(new Vector3(moveXPos, jumpHeight * Time.deltaTime, moveZPos));
        Debug.Log(value.Get());
    }

}
