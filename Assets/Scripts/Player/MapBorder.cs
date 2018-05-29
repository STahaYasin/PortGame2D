using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorder : MonoBehaviour {

    public Texture2D tex;

    float width;
    float borderWidth;

    private Rect l;
    private Rect r;
    private Rect t;
    private Rect b;

    void OnGUI()
    {
        GUI.DrawTexture(l, tex);
    }

	// Use this for initialization
	void Start () {
        width = Screen.width;
        borderWidth = width / 10;

        l = new Rect(0, 0, borderWidth, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
