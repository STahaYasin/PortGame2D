using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinTeam : MonoBehaviour {

    public int LevelToLoad = 0;
    public bool RotateDisplayAtLeave = false;

    public InputField i_teamid;
    public Text text;

    bool ready = false;

	// Use this for initialization
	void Start () {
        string teamid = PlayerPrefs.GetString("team_id", null);
        if(teamid == null || teamid == "")
        {
            ready = true;
        }
        else
        {
            go();
        }
        ready = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void JoinT()
    {
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        string groupid = PlayerPrefs.GetString("group_id", null);
        string teamid = i_teamid.text;
        string userid = PlayerPrefs.GetString("user_id", null);

        string url = StaticMembers.GetRootUrlWithSlash() + "jointeam.php";
        WWWForm form = new WWWForm();
        form.AddField("groupid", groupid);
        form.AddField("teamid", teamid);
        form.AddField("userid", userid);

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
            text.text = res.message;
            storeAndGo(res.data);
        }
        else
        {
            text.text = res.message;
        }
    }
    void storeAndGo(int teamid)
    {
        PlayerPrefs.SetString("team_id", teamid.ToString());

        go();
    }
    void go()
    {
        if (RotateDisplayAtLeave) Screen.orientation = ScreenOrientation.LandscapeLeft;
        Application.LoadLevel(LevelToLoad);
    }
}