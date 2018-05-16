﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGameManager : MonoBehaviour {

    public int MovesOver = 999;
    private int movesDone = 0;

    public Pipe[] pipeArray;
    public bool gameFinnished = false;

	// Use this for initialization
	void Start () {
        startPipes();
	}
    void startPipes()
    {
        foreach (Pipe pipe in pipeArray) pipe.Begin();
    }
	
	// Update is called once per frame
	void Update () {

        checkCLicks();

        bool a = true;
        foreach(Pipe pipe in pipeArray)
        {
            a &= pipe.SitsGood();
        }

        gameFinnished |= a;

        if (gameFinnished)
        {
            foreach (Pipe pipe in pipeArray) pipe.Stop();
        }

        checkStatsus();
	}
    private void checkCLicks()
    {
        int clicks = 0;

        foreach(Pipe pipe in pipeArray)
        {
            clicks += pipe.GetClicks();
        }

        movesDone += clicks;
        MovesOver -= clicks;
    }
    private void checkStatsus()
    {

    }
}
