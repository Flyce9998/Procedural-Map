using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [HideInInspector]
    public enum kind {zoom, multiplier, quality}
    public kind type;
    public Slider slider;
    NoiseGen ng;

    private void Start()
    {
        ng = GetComponentInParent<NoiseGen>();
    }

    public void onSliderChanged()
    {
        switch (type)
        {
            case kind.zoom:
                NoiseGen.scale = (int)slider.value;
                break;
            case kind.multiplier:
                NoiseGen.multiplier = slider.value;
                break;
            case kind.quality:
                NoiseGen.size = (int) (16 * Mathf.Pow(2, slider.value));
                break;
            default:
                break;
        }
        ng.GenNoise();
    }
}
