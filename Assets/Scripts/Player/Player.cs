using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : Character {

    public CharacterController controller;

    public int MoveSpeed = 5;

    public SpriteHolder spriteHolder;
    public SpriteRenderer spriteRenderer;

    public Player()
    {
        
    }
    
	void Start () {
		
	}
	
	void Update () {

        if (spriteHolder == null) return;

        move();

	}
    void move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float xSpeed = inputX;
        float ySpeed = inputY;

        if (Mathf.Abs(inputX) > Mathf.Abs(inputY))
            inputY = 0;
        else
            inputX = 0;

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
    /*public IEnumerator Move(float x, float y)
    {
        bool isMoving = true;
        Vector3 startPos = transform.position;
        float t = 0;

        Vector3 endPos = new Vector3(startPos.x + System.Math.Sign(x), startPos.y + System.Math.Sign(y), startPos.z);

        while (t < 1f)
        {
            t += Time.deltaTime * 3;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }*/
}