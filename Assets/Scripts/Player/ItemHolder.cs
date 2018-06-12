using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder: MonoBehaviour {

    public GameObject panel;
    public GameObject image;

    private bool userCollectionsOpened = false;

    public bool[] collected = new bool[25];
    public Sprite[] ui_textures;
    public Image[] ui_extra_collection_items;
    public Image[] ui_collection_items;
    private Item[] collectedItems = new Item[25];


    public void Start()
    {
    }
	
	void Update () {
        string boolArrayJson = JsonUtility.ToJson(collected);
        boolArrayJson = collected.ToString();
        Debug.Log(boolArrayJson);

        panel.SetActive(userCollectionsOpened);

        if (userCollectionsOpened)
        {
            for(int i = 0; i < collectedItems.Length; i++)
            {
                if (collected[i] == false) continue;

                ui_collection_items[i].sprite = ui_textures[i];
                Debug.Log("fvjfbj");
            }
        }
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
        //image.SetActive(false);
    }
    public void AddItem(Item item)
    {
        if (item == null) return;

        collected[item.CollectionItemNumber - 1] = true;
        //collectedItems[item.CollectionItemNumber - 1] = item;
    }
}