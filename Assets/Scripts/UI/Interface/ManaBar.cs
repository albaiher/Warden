using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;

        gradient.Evaluate(slider.normalizedValue);
    }

    public void setMana(int mana)
    {
        slider.value = mana;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
