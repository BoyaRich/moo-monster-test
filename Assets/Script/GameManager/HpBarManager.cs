using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBarManager : MonoBehaviour
{

    public Slider slider;
    public Vector3 offset;

    public void Sethp(float hp, float maxhp)
    {
        slider.value = hp;
        slider.maxValue = maxhp;
           
    }
    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

}
