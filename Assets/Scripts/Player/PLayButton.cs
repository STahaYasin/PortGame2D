using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayButton : MonoBehaviour {

    public BoatControll Target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUp()
    {
        Debug.Log("vjdhbbfdhkblk");
        Target.Play();
    }
}
