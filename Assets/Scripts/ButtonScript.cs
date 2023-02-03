using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Toggle toggle;
    NoiseGen ng;

    private void Start()
    {
        ng = GetComponentInParent<NoiseGen>();
    }

    public void OnValueChanged()
    {
        NoiseGen.heightMap = toggle.isOn;
        ng.GenNoise();
    }
}
