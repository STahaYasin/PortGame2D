using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Item : MonoBehaviour {

    public string name = "";

    public GameObject showTarget;
    public Image sp;
    public Sprite SpriteToShow;

    public int CollectionItemNumber;
    //public Sprite MiniTexture;

    private string kind = "";
    private int value = 0;

    public string GetName()
    {
        return name;
    }
    public string GetKind()
    {
        return kind;
    }
    private int GetValue()
    {
        return value;
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
    public Sprite GetTexture()
    {
        return null;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        Player player = other.gameObject.GetComponent<Player>();
        player.AddCollectingItem(this);

        showTarget.SetActive(true);
        sp.sprite = SpriteToShow;
        DestroyObject(this.gameObject);
    }
}