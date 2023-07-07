using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class AudioScreen : MonoBehaviour
{
    public AudioMixer mixer;
    public TMP_Text master, music, sfx;
    public Slider masterSlider, musicSlider, sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        //set value of sliders with remembered values from preveous session

        float vol = 0f;
        mixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        master.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        mixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        music.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        mixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
        sfx.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume()
    {
        master.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        mixer.SetFloat("MasterVol", masterSlider.value); //set chosen value to the mixer;

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value); //remembers volume values for next session
    }

    public void SetMusicVolume()
    {
        music.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        mixer.SetFloat("MusicVol", musicSlider.value); //set chosen value to the mixer;

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSfxVolume()
    {
        sfx.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
        mixer.SetFloat("SFXVol", sfxSlider.value); //set chosen value to the mixer;

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}
