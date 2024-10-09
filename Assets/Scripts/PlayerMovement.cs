using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float HorizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    void Update(){
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }   

        if (Input.GetButtonDown("Crouch")){
            crouch = true;

        }   else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

    }

    void FixedUpdate(){
        
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
