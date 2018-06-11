using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAction : MonoBehaviour {

    public int LevelToLoad = 0;
    public bool QuitGame = false;

    public bool SavePosToReturn = false;
    public GameObject PosToReturn;

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

        if (SavePosToReturn)
        {
            PlayerPrefs.SetFloat("mainmap_x", PosToReturn.transform.position.x);
            PlayerPrefs.SetFloat("mainmap_y", PosToReturn.transform.position.y);
            PlayerPrefs.Save();
        }

        Application.LoadLevel(LevelToLoad);
    }
}
