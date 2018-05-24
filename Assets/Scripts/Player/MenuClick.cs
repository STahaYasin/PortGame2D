using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClick : MonoBehaviour {

    public int LevelToLoad = 0;
    public bool QuitApplication = false;


	void Start () {
		
	}

	void Update () {
		
	}
    void OnMouseUp()
    {
        if (QuitApplication)
        {
            Application.Quit();
            return;
        }

        Application.LoadLevel(LevelToLoad);
    }
}