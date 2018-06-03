using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinGroup : MonoBehaviour {

    private bool ready = false;

    public int LevelToLoad;

    public InputField i_username;
    public InputField i_groupid;
    public InputField i_groupkey;
    public Text text;

    public GameObject storedgroup;
    public Text storedgrouptext;

    private string username;
    private string groupid;
    private string groupkey;

    // Use this for initialization
    void Start () {
        string s_userid = PlayerPrefs.GetString("user_id", null); // s_ stands for stored ...
        string s_groupid = PlayerPrefs.GetString("group_id", null);

        if (s_userid == null || s_groupid == null)
        {
            ready = true;
            return;
        }

        StartCoroutine(CheckGroup(s_groupid));
	}
    IEnumerator CheckGroup(string s_groupid)
    {
        string url = StaticMembers.GetRootUrlWithSlash() + "checkifgroupexcits.php";
        WWWForm form = new WWWForm();
        form.AddField("groupid", s_groupid);

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
                gotresultcheck(www.downloadHandler.text);
            }
        }
    }
    void gotresultcheck(string s)
    {
        Result res = JsonUtility.FromJson<Result>(s);
        if (res.success)
        {
            storedgroup.active = true;
            storedgrouptext.text = PlayerPrefs.GetString("group_id", null);
        }
        else
        {
            DeleteKeys();
        }

        ready = true;
    }
    public void DeleteKeys()
    {
        PlayerPrefs.DeleteKey("group_id");
        PlayerPrefs.DeleteKey("user_id");

        storedgroup.active = false;
        storedgrouptext.text = null;
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
            www.timeout = 30;
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

        GoToTeams();
    }
    public void GoToTeams()
    {
        Application.LoadLevel(LevelToLoad);
    }
}