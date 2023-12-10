using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    public void OnButtonPress()
    {
        if(soundOnIcon.enabled == true)
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
        else if (soundOnIcon.enabled == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
    }
}
