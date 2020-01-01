using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizePanel : MonoBehaviour
{

    public GameObject darkSword;
    public GameObject lightSword;


    public void SelectDarkSword()
    {
        GameManager.Instance.selectedSwordPrefab = darkSword;
    }
    
    public void SelectLightSword()
    {
        GameManager.Instance.selectedSwordPrefab = lightSword;
    }
    
}
