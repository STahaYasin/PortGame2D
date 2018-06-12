using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHolderTeam : MonoBehaviour {

    public SpriteOneChar SpritesCustom;
    public SpriteOneChar SpritesCraneOpp;
    public SpriteOneChar SpritesTechnitian;
    public SpriteOneChar SpritesWareHouseOpp;
    public SpriteOneChar SpritesDocter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Sprite GetSprite(int i, int d)
    {
        Debug.Log("Character: " + i);
        SpriteOneChar a = null;

        switch (i)
        {
            case 1: a = SpritesCustom; break;
            case 2: a = SpritesCraneOpp; break;
            case 3: a = SpritesTechnitian; break;
            case 4: a = SpritesWareHouseOpp; break;
            default: a = SpritesDocter; break;
        }

        return a.SpritesNotMoving[0];
    }
}
[System.Serializable]
public class SpriteOneChar
{
    public Sprite[] SpritesNotMoving;
    public Sprite[] SpritesLeft;
    public Sprite[] SpritesRight;
    public Sprite[] SpritesUp;
    public Sprite[] SpritesDown;
}