using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    public Dropdown dropdown;
    NoiseGen ng;
    void Start()
    {
        ng = GetComponentInParent<NoiseGen>();
        dropdown = GetComponent<Dropdown>();
    }
    
    public void OnValueChanged()
    {
        switch (dropdown.value)
        {
            case 0:
                NoiseGen.mode = NoiseGen.modes.normal;
                break;
            case 1:
                NoiseGen.mode = NoiseGen.modes.island;
                break;
            case 2:
                NoiseGen.mode = NoiseGen.modes.lake;
                break;
            default:
                break;
        }
        ng.GenNoise();
    }
}
