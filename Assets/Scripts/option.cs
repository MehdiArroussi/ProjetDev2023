using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class option : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    [SerializeField] private Toggle fullscreenToggle;


    private Resolution[] resolutions;
    private int currentResolutionID;

    private void Awake()
    {
        //Init Resolutions
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> _resolutionLabels = new List<string>();
        for (var i = 0; i < resolutions.Length; i++)
        {
            _resolutionLabels.Add(resolutions[i].width + "x" + resolutions[i].height);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currentResolutionID = i;
        }

        resolutionDropDown.AddOptions(_resolutionLabels);
        
        //Init les valeurs
        resolutionDropDown.value = currentResolutionID;
        fullscreenToggle.isOn = Screen.fullScreen;


        //Link les events
        resolutionDropDown.onValueChanged.AddListener(UpdateResolution);
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscren);
    }

    private void UpdateVolume(float _value)
    {
        print("Audio Mixer : " + _value);
    }

    private void UpdateResolution(int _value)
    {
        currentResolutionID = _value;
        Screen.SetResolution(resolutions[currentResolutionID].width, resolutions[currentResolutionID].height, Screen.fullScreen);
        print("Resolution : " + resolutions[currentResolutionID]);
    }

    private void ToggleFullscren(bool _value)
    {
        Screen.fullScreen = _value;
        print("Fullscreen : " + Screen.fullScreen);
    }
}