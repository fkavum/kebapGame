using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizePanel : MonoBehaviour
{

    public GameObject darkSword;
    public GameObject lightSword;
    public GameObject ordinaryStick;
    public GameObject spike;
    public GameObject sabre;
    public GameObject rapier;
    public GameObject katana;

    public void SelectDarkSword()
    {
        GameManager.Instance.selectedSwordPrefab = darkSword;
    }
    
    public void SelectLightSword()
    {
        GameManager.Instance.selectedSwordPrefab = lightSword;
    }
    
    public void SelectOrdinaryStick()
    {
        GameManager.Instance.selectedSwordPrefab = ordinaryStick;
    }
    
    public void SelectSpike()
    {
        GameManager.Instance.selectedSwordPrefab = spike;
    }
    public void SelectSabre()
    {
        GameManager.Instance.selectedSwordPrefab = sabre;
    }
    public void SelectRapier()
    {
        GameManager.Instance.selectedSwordPrefab = rapier;
    }
    public void SelectKatana()
    {
        GameManager.Instance.selectedSwordPrefab = katana;
    }
    
}
