using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinTeam : MonoBehaviour {

    public InputField i_teamid;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void JoinT()
    {
        Upload();
    }
    IEnumerator Upload()
    {
        string groupid = PlayerPrefs.GetString("group_id", null);
        string teamid = i_teamid.text;

        string url = StaticMembers.GetRootUrlWithSlash() + "jointeam.php";
        WWWForm form = new WWWForm();
        form.AddField("groupid", groupid);
        form.AddField("teamid", teamid);

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

    }
}