using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] float turnSpeed = 2f;

    Vector3 moveInput;
    Animator animator;
    
    bool isSprinting;
    float velocityMax = 1;

    //Blend Tree Variables
    int velocityHash;
    public float velocity; //BlendTree variable Velocity
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;


    void Start()
    {
        velocityMax = 1f;

        animator = GetComponentInChildren<Animator>();
        //used for optimization purposes. Comparing two ints is faster than comparing two strings, used when comparing many animation states
        velocityHash = Animator.StringToHash("Velocity");
    }

    
    void Update()
    {
        AnimateMovement();
    }


    void AnimateMovement()
    {
        if(moveInput.x == 0 && moveInput.y == 0)
        {
            SlowAnimation();
        }

        AnimateWalk();
        animator.SetFloat(velocityHash, velocity);
    }


    void AnimateWalk()
    {
        if(!isSprinting && velocity > 1f) { StopSprint(); }

        if(moveInput.x != 0 && moveInput.y == 0)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if(moveInput.y > 0f && velocity < velocityMax) //Walk animation is set to 2
        {
            velocity += Time.deltaTime * acceleration;
        }
        else if(moveInput.y < 0f && velocity > -1f) //WalkBackward animation is set to -1 
        {
            velocity -= Time.deltaTime * deceleration;
        }
    }


    void OnSprint(InputValue value)
    {
        if(value.isPressed)
        {
            isSprinting = true;
            velocityMax = 2f;
        }
        else if(!value.isPressed)
        {
            isSprinting = false;
            velocityMax = 1f;
        }
    }


    void StopSprint()
    {
        if(velocity > 1f)
        {
            velocity -= Time.deltaTime * deceleration;
        }
        else
        {
            velocity = 1f;
        }
    }


    void SlowAnimation()
    {
        if(velocity >  .01f)
        {
            velocity -= Time.deltaTime * deceleration;
        }
        else if(velocity < -.01f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        else
        {
            velocity = 0f;
        }
    }


    void OnMove(InputValue value)
    {   
        moveInput = value.Get<Vector2>();
    }

}
