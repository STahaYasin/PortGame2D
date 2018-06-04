using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder: MonoBehaviour {

    public Texture2D collectableBackground;
    public Texture2D collectableEmpty;
    public Texture2D boxBackground;

    public GameObject panel;

    private bool userCollectionsOpened = false;

    private List<Item> collectedItems = new List<Item>();

    private float screenWidth;
    private float boxWidth;
    private float boxHeight;
    private Rect boxRect;

    public void Start()
    {
        screenWidth = Screen.width;
        boxWidth = ((screenWidth / 2) - (screenWidth / 20) - (screenWidth / 20));
        boxHeight = (boxWidth / 612) * 420;
        boxRect = new Rect((screenWidth / 2) + (screenWidth / 20), (Screen.height - boxHeight) / 2, boxWidth, boxHeight);
    }
	
	void Update () {
        panel.SetActive(userCollectionsOpened);
	}
    public void Draw()
    {
        if (userCollectionsOpened)
        {
            DrawCollectables();
        }
    }
    private void DrawCollectables()
    {
        //GUI.DrawTexture(boxRect, boxBackground);
        /*GUI.TextArea(boxRect, Screen.width.ToString() + Screen.height.ToString());

        int countOfCollectables = 25;
        float screenWidth = Screen.width;
        float itemTotalWidth = screenWidth / countOfCollectables;
        float itemMargin = itemTotalWidth / 5;
        float itemWidth = itemTotalWidth - (itemMargin * 2);

        GUI.DrawTexture(new Rect(0, 0, screenWidth, itemWidth + (itemMargin * 2)), collectableBackground);

        for (int i = 0; i < countOfCollectables; i++)
        {
            Rect rect = new Rect((itemTotalWidth * i) + itemMargin, itemMargin, itemWidth, itemWidth);
            GUI.DrawTexture(rect, collectableEmpty);
        }
        for (int i = 0; i < collectedItems.Count; i++)
        {
            Rect rect = new Rect((itemTotalWidth * i) + itemMargin, itemMargin, itemWidth, itemWidth);
            GUI.DrawTexture(rect, collectedItems[i].MiniTexture);
        }*/
    }
    void OnMouseUp()
    {
        userCollectionsOpened = !userCollectionsOpened;
    }
    public void AddItem(Item item)
    {
        if (item == null) return;

        collectedItems.Add(item);
        Debug.Log(collectedItems[collectedItems.Count - 1].GetName());
    }
}