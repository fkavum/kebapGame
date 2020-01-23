using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{

    private UIGradient m_uiGradient;

    public UIGradient uiGradient
    {
        get { return m_uiGradient; }
    }
 
    public Color mainBgColor1;
    public Color mainBgColor2;
    
    public Color bossBgColor1;
    public Color bossBgColor2;

    private void Start()
    {
       m_uiGradient = gameObject.GetComponent<UIGradient>();
    }

    public void changeToBossColor()
    {
        m_uiGradient.m_color1 = bossBgColor1;
        m_uiGradient.m_color2 = bossBgColor2;
    }
    
}
