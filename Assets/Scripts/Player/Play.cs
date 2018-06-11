using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{

    public int LevelToLoad = 0;
    public bool QuitApplication = false;
    public bool RotateAtLeave = false;

    //public InputField input;


    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        //input.text = PlayerPrefs.GetString("player_name");
    }

    void Update()
    {

    }
    void OnMouseUp()
    {
        //string name = PlayerPrefs.GetString("player_name", null);
        //string inputName = input.text;

        /*if(name == null)
        {
            if (inputName == null || inputName == "")
            {
                PlayerPrefs.SetString("player_name", "Unnamed player");
            }
            else
            {
                PlayerPrefs.SetString("player_name", inputName);
            }
        }
        else
        {
            if (inputName == null || inputName == "")
            {

            }
            else
            {
                PlayerPrefs.SetString("player_name", inputName);
            }
        }*/

        if(RotateAtLeave) Screen.orientation = ScreenOrientation.LandscapeLeft;

        if (QuitApplication)
        {
            Application.Quit();
            return;
        }

        Application.LoadLevel(LevelToLoad);
    }
}