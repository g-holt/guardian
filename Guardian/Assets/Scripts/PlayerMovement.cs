using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

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
        moveZPos = moveInput.y * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveXPos, 0f, moveZPos));
    }


    void OnMove(InputValue value)
    {   
        moveInput = value.Get<Vector2>();
    }

}