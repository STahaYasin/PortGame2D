using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CollectebleItemHandler : MonoBehaviour, IPointerClickHandler
{

    public bool Enabled;

    public int Level = 0;
    public int Itemnr = 0;

    public GameObject ImageToEnable;
    public Image image;
    public Sprite BigImage;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Enable()
    {
        Enabled = true;
    }
    public void OnPointerClick(PointerEventData eventData) // 3
    {
        if (!Enabled) return;

        ImageToEnable.SetActive(true);
        image.sprite = BigImage;
    }
}