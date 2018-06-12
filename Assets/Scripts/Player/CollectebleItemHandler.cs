using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectebleItemHandler : MonoBehaviour {

    public int Level = 0;
    public int Itemnr = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerClick(PointerEventData eventData) // 3
    {
        Debug.Log("clicked");
    }
}