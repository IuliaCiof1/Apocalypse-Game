using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsScreen : MonoBehaviour
{
    public Toggle fullscreen;
    public TMPro.TMP_Dropdown resDropdown;
    private Resolution[] res;
    // Start is called before the first frame update
    void Start()
    {
        fullscreen.isOn = Screen.fullScreen;

        res = Screen.resolutions;
        int currentRes=0;

        for(int i = 0; i < res.Length; i++)
        {
            resDropdown.options[i].text = ResToString(res[i]);
            resDropdown.value = i;
            resDropdown.options.Add(new TMPro.TMP_Dropdown.OptionData(resDropdown.options[i].text));

            if (res[i].Equals(Screen.currentResolution))
            {
                currentRes = i;
                Debug.Log(currentRes + " " + Screen.currentResolution);
            }
        }
        resDropdown.value = currentRes;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string ResToString(Resolution res)
    {
        return res.width + "x" + res.height;
    }

    public void ApllyGraphics()
    {
        Screen.fullScreen = fullscreen.isOn;

        string[] s = resDropdown.options[resDropdown.value].text.Split('x');
        Screen.SetResolution(Int32.Parse(s[0]), Int32.Parse(s[1]) , fullscreen.isOn);
    }

}
