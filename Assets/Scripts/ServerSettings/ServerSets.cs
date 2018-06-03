using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ServerSets : MonoBehaviour {

    public int LevelToReturn = 0;

    private bool ready = false;
    private bool remote;
    private string ipaddress;

    public Toggle Togle;
    public InputField inputfield;
    public GameObject TextFieldToDisable;
    public Image TestButton;

	// Use this for initialization
	void Start () {
        int a = PlayerPrefs.GetInt("server_remote", 1);
        remote = a == 0 ? false : true;
        ipaddress = PlayerPrefs.GetString("server_address", "192.168.0.1");

        inputfield.text = ipaddress;
        Togle.isOn = remote;

        ready = true;
	}
    public void SaveValue()
    {
        remote = Togle.isOn;
        ipaddress = inputfield.text;

        //Set
        PlayerPrefs.SetInt("server_remote", remote ? 1 : 0);
        PlayerPrefs.SetString("server_address", ipaddress);
        PlayerPrefs.Save();

        Application.LoadLevel(LevelToReturn);
    }
    public void TestConnectivity()
    {
        StartCoroutine(Upload());
    }
	
	// Update is called once per frame
	void Update () {
        if (!ready) return;

        TextFieldToDisable.SetActive(!Togle.isOn);
	}
    IEnumerator Upload()
    {
        string url = remote ? StaticMembers.GetUrlWithSlash() : inputfield.text + "/"; //This does not use the static method becouse it is used when the settings are not saved jet;
        url += "port/port/app/checkconn.php";
        WWWForm form = new WWWForm();
        form.AddField("test", "TahaYasinTest1");

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.timeout = 5;
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Result res = new Result();
                res.success = false;
                res.message = www.error;
                gotResult(JsonUtility.ToJson(res));
            }
            else
            {
                gotResult(www.downloadHandler.text);
            }
        }
    }
    void gotResult(string s)
    {
        Result res = JsonUtility.FromJson<Result>(s);
        Debug.Log(res.message);

        if (res.success)
        {
            //TestButton.material.color = Color.green;
            TestButton.color = Color.green;
        }
        else
        {
            //TestButton.material.color = Color.red;
            TestButton.color = Color.red;
        }
    }
}