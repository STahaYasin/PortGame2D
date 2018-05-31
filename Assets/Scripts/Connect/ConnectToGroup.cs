using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectToGroup : MonoBehaviour {

    

    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("test", "TahaYasinTest1");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/port/port/app/checkconn.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                gotResult(www.downloadHandler.text);
            }
        }
    }
    void gotResult(string s)
    {
        Debug.Log(s);
    }
}
