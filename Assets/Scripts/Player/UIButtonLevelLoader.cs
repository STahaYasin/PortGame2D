using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonLevelLoader : MonoBehaviour {

    public int LevelToLoad = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Go()
    {
        Application.LoadLevel(LevelToLoad);
    }
}
