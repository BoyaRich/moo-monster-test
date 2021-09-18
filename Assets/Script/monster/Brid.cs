using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brid : Monster
{
    public HpBarManager hpbar;
    
    private void Start()
    {
        hpbar = transform.GetChild(0).GetComponent<HpBarManager>();
        hpbar.Sethp(HP, Hpmax);

    }
    private void Update()
    {
        hpbar.Sethp(HP, Hpmax);
    }
}
