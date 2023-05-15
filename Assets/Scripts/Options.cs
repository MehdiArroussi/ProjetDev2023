using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{

   public Dropdown DResolution;

   public AudioSource audiosource;
   public Slider slider;
   public Text TxtVolume;

    void update (){
        
    }
    public void SetResolution(){
        switch (DResolution.value)
        {
            
            case 0:
                Screen.SetResolution(640,360,true);
                break;
            case 1:
                Screen.SetResolution(1280,1024,true);
                break;
            case 2:
                Screen.SetResolution(1920,1080,true);
                break;
        }
    }
    public void SliderChanger()
    {
        audiosource.volume = slider.value;
        TxtVolume.text = "Volume " + (audiosource.volume * 100 ).ToString("00") + "%";
    }
}