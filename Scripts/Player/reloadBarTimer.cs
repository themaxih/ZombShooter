using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reloadBarTimer : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTime()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    public void SetTime()
    {
        slider.value = 0;
    }
}
