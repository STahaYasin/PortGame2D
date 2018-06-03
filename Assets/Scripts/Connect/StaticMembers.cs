﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMembers : MonoBehaviour {

    public static string ServerRemoteName = "server_remote";
    public static string ServerIpAddressName = "server_address";
    public static string Host = "http://localhost";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static string GetUrl()
    {
        if(PlayerPrefs.GetInt(ServerRemoteName, 1) == 1)
        {
            return Host;
        }
        else
        {
            return PlayerPrefs.GetString(ServerIpAddressName, Host);
        }
    }
    public static string GetUrlWithSlash()
    {
        return GetUrl() + "/";
    }
}