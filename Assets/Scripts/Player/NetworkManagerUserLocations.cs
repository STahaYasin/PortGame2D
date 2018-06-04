using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerUserLocations : MonoBehaviour {

    public GameObject Player;

    private string userid;

    public TeamPlayer[] TeamMembers;

	// Use this for initialization
	void Start () {
        userid = PlayerPrefs.GetString("user_id", null);
        if (userid == null) Application.LoadLevel(0);

        UpdatePos();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdatePos()
    {
        if (userid == null) StartCoroutine(JustWait());
        else
        {
            StartCoroutine(Upload());
        }
    }

    IEnumerator Upload()
    {
        string url = StaticMembers.GetRootUrlWithSlash() + "updatepos.php";
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("x", Player.transform.position.x.ToString());
        form.AddField("y", Player.transform.position.y.ToString());
        form.AddField("level", "0.1");

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.timeout = 30;
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                //text.text = www.error;
                Debug.Log(www.error);
            }
            else
            {
                gotResult(www.downloadHandler.text);
            }
        }

        //yield return new WaitForSeconds(0.05f);
        UpdatePos();
    }
    void gotResult(string s)
    {
        ResultForUserPos res = JsonUtility.FromJson<ResultForUserPos>(s);

        Debug.Log(res.data.Length);
        
        if(res.data.Length > 0)
        {
            TeamMembers[0].UpdatePos(res.data[0]);
        }
        if (res.data.Length > 1)
        {
            TeamMembers[1].UpdatePos(res.data[1]);
        }
        if (res.data.Length > 2)
        {
            TeamMembers[2].UpdatePos(res.data[2]);
        }
        if (res.data.Length > 3)
        {
            TeamMembers[3].UpdatePos(res.data[3]);
        }
    }
    IEnumerator JustWait()
    {
        yield return new WaitForSeconds(5);
        UpdatePos();
    }
}