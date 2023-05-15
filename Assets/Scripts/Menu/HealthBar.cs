using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : charactee
{
    public Slider slider;

    public void setmax(int HPplayer){
        slider.maxValue = HPplayer;
        slider.value =HPplayer;
    }
    public void SetHealth(int HPplayer){
        slider.value= HPplayer;
    }
}
