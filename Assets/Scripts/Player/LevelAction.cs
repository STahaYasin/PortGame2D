using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAction : MonoBehaviour {

    public int LevelToLoad = 0;
    public bool QuitGame = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (QuitGame) Application.Quit();

        Application.LoadLevel(LevelToLoad);
    }
}
