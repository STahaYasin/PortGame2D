using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHolder : MonoBehaviour
{
    private int currentSpriteState = 0;

    public Sprite[] Sprites_NotMoving;
    public Sprite[] Sprites_left;
    public Sprite[] Sprites_right;
    public Sprite[] Sprites_top;
    public Sprite[] Sprites_down;

    void Start()
    {

    }

    void Update()
    {

    }
    public void SetDirection(int code)
    {
        currentSpriteState = code;
    }
    public void GetCurrentSprite()
    {

    }
    private Sprite[] getSpriteArray()
    {
        switch (currentSpriteState)
        {
            case 0: return Sprites_NotMoving;
            case 1: return Sprites_left;
            case 2: return Sprites_right;
            case 3: return Sprites_top;
            case 4: return Sprites_down;

            default: return null;
        }

        return Sprites_left;
    }
}