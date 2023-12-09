using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSliderController : MonoBehaviour
{
    public Slider sliderInstance;

    private SFXManager sfxManager;
    // Start is called before the first frame update
    void Start()
    {
        sfxManager = SFXManager.Instance;
    }

    public void OnValueChanged(float value) 
    {
        sfxManager.SetSfxLvl(value);
    }
}
