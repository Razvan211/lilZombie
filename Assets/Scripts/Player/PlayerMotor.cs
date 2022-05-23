using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour

{
    Animator animator;
    
   
    private CharacterController controller;
    private Vector3 playerVel;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpH = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
       
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVel.y = Mathf.Sqrt(jumpH * -4f * gravity);
        }
    }
    //receive inputs from InputManager and uses them in the controller

    public void ProcessMove (Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVel.y += gravity * Time.deltaTime;
        if (isGrounded && playerVel.y < 0)
            playerVel.y = -2f;
        controller.Move(playerVel * Time.deltaTime);
        
        if(input.x > 0 || input.x < 0 || input.y > 0 || input.y < 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


       

     


    }

  
}
