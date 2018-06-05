using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder: MonoBehaviour {

    public GameObject panel;

    private bool userCollectionsOpened = false;

    private List<Item> collectedItems = new List<Item>();


    public void Start()
    {
    }
	
	void Update () {
        panel.SetActive(userCollectionsOpened);
	}
    public void Draw()
    {
        
    }
    void OnMouseUp()
    {
        userCollectionsOpened = !userCollectionsOpened;
    }
    public void CloseCollectionsBox()
    {
        userCollectionsOpened = false;
    }
    public void AddItem(Item item)
    {
        if (item == null) return;

        collectedItems.Add(item);
        Debug.Log(collectedItems[collectedItems.Count - 1].GetName());
    }
}