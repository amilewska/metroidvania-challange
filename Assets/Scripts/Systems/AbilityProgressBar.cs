using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityProgressBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public int maxProgress = 4;

    public Image fill;

    private void Start()
    {
        slider.value = 0;

        fill.color = gradient.Evaluate(1f);
    }
     public bool IsMax()
    {
        return slider.value >= slider.maxValue;
    }

    public void AddProgress(int progress)
    {
        slider.value += progress;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
