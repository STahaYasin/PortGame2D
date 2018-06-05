using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResultForUserPos
{
    public bool success;
    public int status;
    public string message;
    public UserPos[] data;
}