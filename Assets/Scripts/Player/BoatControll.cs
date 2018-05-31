using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControll : MonoBehaviour
{

    public int Speed = 5;
    public ConstantForce Boat;

    private bool started = false;
    private float screenwidth;
    private float pauseWidth;
    private Rect pauseReect;

    public void Play()
    {
        go();
    }
    private void go()
    {
        GetComponent<Rigidbody>().AddForce(0, 250, 0);
    }
    private void stop()
    {

    }

	// Use this for initialization
	void Start () {
        screenwidth = Screen.width;
        pauseWidth = screenwidth / 15;
        pauseReect = new Rect(pauseWidth / 2, pauseWidth / 2, pauseWidth, pauseWidth);
	}

    void OnGUI()
    {
        if (started)
        {
            //Draw pause button
            if (GUI.Button(pauseReect, "||"))
            {

            }
        }
        else
        {
            //Draw Start button
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

//https://unity3d.com/learn/tutorials/topics/mobile-touch/accelerometer-input