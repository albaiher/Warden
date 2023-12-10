using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Image soundOnIcon;
    [SerializeField] private Image soundOffIcon;
    public Slider sliderInstance;

    private float sound = 0.0f;

    public void OnButtonPress()
    {
        if (soundOnIcon.enabled == true)
        {
            ShowMuteIcon();
            Mute();
        }
        else if (soundOnIcon.enabled == false)
        {
            ShowUnMuteIcon();
            UnMute();
        }
    }

    void Update()
    {
        if (sliderInstance.value != 0.001f)
        {
            ShowUnMuteIcon();
        }
        else 
        {
            ShowMuteIcon();
        }
    }

    public void Mute()
    {
        sound = sliderInstance.value;
        sliderInstance.value = 0.001f;
    }

    private void ShowMuteIcon() 
    {
        if (soundOffIcon.enabled) return;

        soundOnIcon.enabled = false;
        soundOffIcon.enabled = true;
    }

    private void ShowUnMuteIcon()
    {
        if (soundOnIcon.enabled) return;
        soundOnIcon.enabled = true;
        soundOffIcon.enabled = false;
    }
    public void UnMute()
    {
        sliderInstance.value = sound;
    }
}
