﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : Character {

    public CharacterController controller;

    public float MoveSpeed = 1f;

    public SpriteHolder spriteHolder;
    public SpriteRenderer spriteRenderer;

    private Vector2 userInput = -Vector2.one;
    private bool userInputStarted = false;
    private int joystickIsAtIndex = -1;

    //Floats to hold the input move speed
    private float xSpeed = 0;
    private float ySpeed = 0;

    public Player()
    {
        
    }
    
	void Start () {
        Debug.Log("PLayer started");
	}
	
	void Update () {

        if (spriteHolder == null) return;

        move();

	}
    void move()
    {
        //float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");

        bool joystickIsAlreadyTouched = false;

        for(int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            if(touch.position.x < (Screen.width / 2))
            {
                if (!joystickIsAlreadyTouched)
                {
                    joystickIsAlreadyTouched = true;

                    if (touch.phase == TouchPhase.Began)
                    {
                        userInput = touch.position;
                        userInputStarted = true;
                        joystickIsAtIndex = i;
                    }
                }
            }
            else
            {

            }

            if (userInputStarted && i == joystickIsAtIndex)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 currentUserInput = touch.position;
                    Debug.Log(currentUserInput.x);

                    Vector2 posss = transform.position;

                    xSpeed = (touch.position.x - userInput.x) / 275;
                    ySpeed = (touch.position.y - userInput.y) / 275;
                    transform.position = posss;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    userInputStarted = false;
                    joystickIsAtIndex = -1;
                    xSpeed = 0;
                    ySpeed = 0;
                }
            }
        }

        xSpeed += Input.GetAxis("Horizontal") / 3;
        ySpeed += Input.GetAxis("Vertical") / 3;

        if (xSpeed >= 1) xSpeed = 1;
        else if(xSpeed <= -1) xSpeed = -1;
        if (ySpeed >= 1) ySpeed = 1;
        else if (ySpeed <= -1) ySpeed = -1;

        float inputX = xSpeed;
        float inputY = ySpeed;

        //float xSpeed = inputX;
        //float ySpeed = inputY;

        if (Mathf.Abs(inputX) > Mathf.Abs(inputY))
        {
            inputY = 0;
            //ySpeed /= 1.5f;
            ySpeed = 0;
        }
        else
        {
            inputX = 0;
            //xSpeed /= 1.5f;
            xSpeed = 0;
        }

        //if(xSpeed != 0 && ySpeed != 0)
        //{
            if (inputX > 0) // Numbers are the same as the numpad control
                spriteHolder.SetDirection(6);
            else if (inputX < 0)
                spriteHolder.SetDirection(4);
            else if (inputY > 0)
                spriteHolder.SetDirection(8);
            else if (inputY < 0)
                spriteHolder.SetDirection(2);
            else
                spriteHolder.SetDirection(5);
        //}

        setSprite();

        //Debug.Log(spriteHolder.GetDirectionName()); // It works, the direction are right // Debugs are deleted becouse it slows down the program

        //StartCoroutine(Move(inputX, inputY));

        /*Vector2 pos = transform.position;
        pos.x += xSpeed * Time.deltaTime * 5;
        pos.y += ySpeed * Time.deltaTime * 5;

        transform.position = pos;*/

        Vector3 moveDirection = Vector3.zero;

        moveDirection = new Vector3(xSpeed * MoveSpeed, ySpeed * MoveSpeed, 0);
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);

    }
    private void setSprite()
    {
        if (spriteRenderer == null) return;
        spriteRenderer.sprite = spriteHolder.GetSprite();
    }
    public void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log("fbgfb");
    }
}