using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            if (touch.position.x < (Screen.width / 2) - (Screen.width / 8))
            {

            }
        }
        if(Input.touchCount > 0)
        {
            int a = 0;

            Touch touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                Debug.Log("Left");
                a = -5;
            }
            else
            {
                Debug.Log("Right");
                a = 5;
            }

            transform.Translate(a * Time.deltaTime, 0, 0);
        }
    }
}