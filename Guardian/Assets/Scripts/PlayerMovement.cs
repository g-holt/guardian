using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 2f;

    Rigidbody rb;
    Animator animator;
    Vector3 moveInput;
    Vector3 playerMovement;
    
    float moveXPos;
    float moveYPos;
    float moveZPos;

    //Blendtree Variables
    float locomotion; //BlendTree variable Locomotion
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int locomotionHash;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        //used for optimization purposes. Comparing two ints is faster than comparing two strings, used when comparing many animation states
        locomotionHash = Animator.StringToHash("Locomotion");
    }

    
    void Update()
    {
        Move();
    }


    void Move()
    {
        if(!Keyboard.current.wKey.isPressed && !Keyboard.current.sKey.isPressed)
        {
            SlowMovement();
        }   

        if(moveInput.y > 0f && locomotion < 2f) //RamRun animation is set to 2
        {
            locomotion += Time.deltaTime * acceleration;
        }
        else if(moveInput.y < 0f && locomotion > -1f) //WalkBackward animation is set to -1
        {
            locomotion -= Time.deltaTime * deceleration;
        }
        
        animator.SetFloat(locomotionHash, locomotion);
    }


    void SlowMovement()
    {
        if(locomotion >  .01f)
        {
            locomotion -= Time.deltaTime * deceleration;
        }
        else if(locomotion < -.01f)
        {
            locomotion += Time.deltaTime * acceleration;
        }
        else
        {
            locomotion = 0f;
        }
    }


    // void OnMove(InputValue value)
    // {   
    //     moveInput = value.Get<Vector2>();
    // }


    void OnJump(InputValue value)
    {
        if(!value.isPressed) { return; }
        
        rb.velocity = new Vector3(0f, jumpHeight, 0f);
        Debug.Log(value.Get());
    }

}



/*  Before trying to animate using the blend Tree


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
        
        rb.velocity = new Vector3(0f, jumpHeight, 0f);
        Debug.Log(value.Get());
    }


*/