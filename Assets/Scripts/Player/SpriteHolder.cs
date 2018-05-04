using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteHolder : MonoBehaviour
{
    private int currentSpriteState = 5; // 5 Means not moving
    private int currentAnimState = 0;
    private float lastUpdateTime = 0;
    private float updateCooler = 0.2f;
    

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
        float currentTime = Time.time;

        if(currentTime > lastUpdateTime + updateCooler)
        {
            if (currentAnimState < getSpriteArray().Length - 1)
                currentAnimState++;
            else
                currentAnimState = 0;

            lastUpdateTime = currentTime;
        }
    }
    public void SetDirection(int direction) // Numbers are the same as the numpad control
    {
        if (direction == currentSpriteState) return;

        currentSpriteState = direction;
        currentAnimState = 0;
    }
    private Sprite[] getSpriteArray()
    {
        switch (currentSpriteState)
        {
            case 5: return Sprites_NotMoving;
            case 4: return Sprites_left;
            case 6: return Sprites_right;
            case 8: return Sprites_top;
            case 2: return Sprites_down;

            default: return null;
        }
    }
    public string GetDirectionName()
    {
        switch (currentSpriteState)
        {
            case 5: return "Not moving";
            case 4: return "Left";
            case 6: return "Right";
            case 8: return "Top";
            case 2: return "Down";

            default: return null;
        }
    }
    public Sprite GetSprite()
    {
        return getSpriteArray()[currentAnimState];
    }
}