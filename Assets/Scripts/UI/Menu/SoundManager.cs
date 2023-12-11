using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Image soundOnIcon;
    [SerializeField] private Image soundOffIcon;
    [SerializeField] private string source;
    public Slider sliderInstance;

    private float sound = 0.0f;

    private SFXManager sfxManager;

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

    void Start() 
    {
        sfxManager = SFXManager.Instance;
        switch (source)
        {
            case "Master":
                sliderInstance.value = sfxManager.MasterLvl;
                break;
            case "Music":
                sliderInstance.value = sfxManager.MusicLvl;
                break;
            case "Sfx":
                sliderInstance.value = sfxManager.SfxLvl;
                break;

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


    public void OnValueChanged(float level) 
    {
        switch (source) 
        {
            case "Master":
                sfxManager.SetMasterLvl(level);
                break;
            case "Music":
                sfxManager.SetMusicLvl(level);
                break;
            case "Sfx":
                sfxManager.SetSfxLvl(level);
                break;

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
