using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class ApplicationHttp{

	void Start () {
		
	}

	void Update () {
        
	}
    public static string Post()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("data=value"));

        UnityWebRequest www = UnityWebRequest.Post("http://www.tahayasin.be", formData);
        UnityWebRequest wwww = UnityWebRequest.Get("http://www.tahayasin.be");

        if (www == null) Debug.LogWarning("WWW is empty");

        www.SendWebRequest();

        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
            return null;
        }
        else
        {
            string text = www.downloadHandler.text;
            Debug.Log(text);
            return text;
        }
    }
}