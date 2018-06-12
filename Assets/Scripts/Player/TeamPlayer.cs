using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPlayer : MonoBehaviour {

    public int userid;
    public string LevelCode = "0.1";
    public SpriteRenderer sp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetSprite(Sprite s)
    {
        sp.sprite = s;
    }
    public void UpdatePos(UserPos u)
    {
        userid = u.userid;
        Debug.Log(u.level);
        Debug.Log(LevelCode);
        /*foreach(UserPos userp in userpos)
        {
            if(userp.userid == userid)
            {
                if(userp.level == LevelCode)
                {
                    Vector3 transf = transform.position;
                    transf.x = float.Parse(userp.x);
                    transf.y = float.Parse(userp.y);
                    transform.position = transf;
                }
                else
                {

                }
            }
        }*/
        
        if (u.level == LevelCode)
        {
            sp.enabled = true;
            Vector3 transf = transform.position;
            transf.x = float.Parse(u.x);
            transf.y = float.Parse(u.y);
            transform.position = transf;
        }
        else
        {
            sp.enabled = false;
        }
    }
}