using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1;
    }

    
}
