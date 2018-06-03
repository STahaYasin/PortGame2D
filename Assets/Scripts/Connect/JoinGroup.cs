using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinGroup : MonoBehaviour {

    public int LevelToLoad;

    public InputField i_username;
    public InputField i_groupid;
    public InputField i_groupkey;
    public Text text;

    private string username;
    private string groupid;
    private string groupkey;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void JoinG()
    {
        //Check if filled in

        username = i_username.text;
        groupid = i_groupid.text;
        groupkey = i_groupkey.text;

        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        string url = StaticMembers.GetRootUrlWithSlash() + "joingroupbus.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("groupid", groupid);
        form.AddField("groupkey", groupkey);

        /*
        Debug.Log(url);
        Debug.Log(username);
        Debug.Log(groupid);
        Debug.Log(groupkey);
        */

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.timeout = 5;
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                text.text = www.error;
            }
            else
            {
                gotResult(www.downloadHandler.text);
            }
        }
    }
    void gotResult(string s)
    {
        ResultForJoin res = JsonUtility.FromJson<ResultForJoin>(s);
        if (res.success)
        {
            text.text = res.data.ToString();

            storeAndGoToTeams(res);
        }
        else
        {
            text.text = res.message;
        }
    }
    void storeAndGoToTeams(ResultForJoin res)
    {
        PlayerPrefs.SetString("group_id", groupid);
        PlayerPrefs.SetString("user_id", res.data.ToString());

        Application.LoadLevel(LevelToLoad);
    }
}