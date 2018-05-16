using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public int PipeIsLookingTo = 0;
    public int PipeHasToLookTo = 0;
    public bool DirectionDoesntMather = false;

    private int clicks = 0;

	void Start () {
		
	}
	
	void Update () {
		
	}
    void OnMouseDown()
    {
        Debug.Log("click");

        clicks++;

        changeLookingDirection();
    }
    private void changeLookingDirection()
    {
        if (PipeIsLookingTo < 3) PipeIsLookingTo++;
        else PipeIsLookingTo = 0;

        rotate();
    }
    private void rotate()
    {
        Quaternion rot = gameObject.transform.rotation;

        int i = 0;

        switch (PipeIsLookingTo)
        {
            case 0: i = 0; break;
            case 1: i = 270; break;
            case 2: i = 180; break;
            case 3: i = 90; break;
        }

        rot.z = i;
        //gameObject.transform.rotation = rot;

        transform.Rotate(0, 0, -90);
    }
    public int GetClicks()
    {
        int a = clicks;
        clicks = 0;
        return a;
    }
    public bool SitsGood()
    {
        return DirectionDoesntMather | PipeIsLookingTo == PipeHasToLookTo;
    }
}
