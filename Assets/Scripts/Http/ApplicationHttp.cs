using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class ApplicationHttp : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        
	}
    private void Post()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("data=value"));

        UnityWebRequest www = UnityWebRequest.Post("http://www.tahayasin.be", formData);
        UnityWebRequest wwww = UnityWebRequest.Get("http://www.tahayasin.be");

        StartCoroutine(Excecute(www));
    }

    IEnumerator Excecute(UnityWebRequest www)
    {
        if (www == null) Debug.LogWarning("WWW is empty");

        yield return www.SendWebRequest();

        if(www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string text = www.downloadHandler.text;
            Debug.Log(text);
        }
    }
}