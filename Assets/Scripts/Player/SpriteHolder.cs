using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteHolder : MonoBehaviour
{
    private int currentSpriteState = 5; // 5 Means not moving
    private int currentAnimState = 0;
    private float lastUpdateTime = 0;
    private float updateCooler = 0.25f;

    private int character = 0;

    public SpriteOneChar SpritesCustom;
    public SpriteOneChar SpritesCraneOpp;
    public SpriteOneChar SpritesTechnitian;
    public SpriteOneChar SpritesWareHouseOpp;
    public SpriteOneChar SpritesDocter;

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
        SpriteOneChar s;

        switch (character)
        {
            case 1: s = SpritesCustom; break;
            case 2: s = SpritesCraneOpp; break;
            case 3: s = SpritesTechnitian; break;
            case 4: s = SpritesWareHouseOpp; break;
            default: s = SpritesDocter; break;
        }



        switch (currentSpriteState)
        {
            case 5: return s.SpritesNotMoving;
            case 4: return s.SpritesLeft;
            case 6: return s.SpritesRight;
            case 8: return s.SpritesUp;
            case 2: return s.SpritesDown;

            default: return null;
        }
    }
    public void SetCharacter(int i)
    {
        character = i;
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