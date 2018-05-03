using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private SpriteHolder spriteHolder;

    public Player()
    {
        spriteHolder = new SpriteHolder();
    }
    
	void Start () {
		
	}
	
	void Update () {

        move();

	}
    void move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        int a = 
    }
}