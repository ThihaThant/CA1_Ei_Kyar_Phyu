using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2023-08-21
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
//#define DEBUG_DrawMousePoint

//namespace WAPIGS{
//[RequireComponent(typeof(Rigidbody))]
public class SettingMenu : MonoBehaviour 
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixerTwo;
    public Slider brightness_slider;
    public Light sceneLight;

    void Start()
    {
        float savedBrightness = GameManager.Instance.GetBrightness();
        brightness_slider.value = savedBrightness;
        sceneLight.intensity = savedBrightness;
    }

    void Update()
    {
        sceneLight.intensity = brightness_slider.value;
        SaveBrightness();
    }

    public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetVolumeForSoundFX(float volume)
    {
        //Debug.Log(volume);
        audioMixerTwo.SetFloat("VolumeTwo", volume);
    }


    public void SaveBrightness()
    {
       GameManager.Instance.SetBrightness(brightness_slider.value);
    }
}
//}