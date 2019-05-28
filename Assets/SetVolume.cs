using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider sfxSlider;
    public Slider musicSlider;
    public AudioManager mgr;
    public void Update()
    {
        if (sfxSlider != null)
        {
            //Debug.Log(sfxSlider.value);
            mgr.ChangeSFXVolume(sfxSlider.value);
        }
        if (musicSlider != null)
        {
            //Debug.Log(musicSlider.value);
            mgr.ChangeMusicVolume(musicSlider.value);
        }
    }
}
