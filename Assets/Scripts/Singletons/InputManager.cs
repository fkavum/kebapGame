using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    public bool touchAvaible = false;
    public bool isTouchedForStab = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (touchAvaible)
            {
                isTouchedForStab = true;
            } 
        }
    }


    private void LateUpdate()
    {
        isTouchedForStab = false;
    }
}
