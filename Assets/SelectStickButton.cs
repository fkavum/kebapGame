using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK.Setup;
using UnityEngine;

public class SelectStickButton : MonoBehaviour
{
    private CustomizePanel _customizePanel;
    public CustomizePanel customizePanel
    {
        get
        {
            if (!_customizePanel)
                _customizePanel = FindObjectOfType<CustomizePanel>();

            return _customizePanel;
        }
    }
    
    
    public GameObject stickPrefab;
    public bool interactable = false;
    public GameObject lockedImg;
    public GameObject isSelectedObj;

    private void Awake()
    {
      
       Init();
    }

    public void Init()
    {
        if (PlayerPrefs.HasKey(stickPrefab.gameObject.name) && PlayerPrefs.GetInt(stickPrefab.gameObject.name) == 1)
        {
            interactable = true;
            lockedImg.SetActive(false);

            if (PlayerPrefs.GetString("SelectedSword") == stickPrefab.gameObject.name)
            {
                GameManager.Instance.selectedSwordPrefab = stickPrefab;
            }
            
        }
        else
        {
            interactable = false;
            lockedImg.SetActive(true);
        }
    }

    public void SelectStick()
    {
        if (PlayerPrefs.HasKey(stickPrefab.gameObject.name) && PlayerPrefs.GetInt(stickPrefab.gameObject.name) == 1)
        {
            GameManager.Instance.selectedSwordPrefab = stickPrefab;
            PlayerPrefs.SetString("SelectedSword",stickPrefab.gameObject.name);
            customizePanel.UnSelectAllButtons();
            isSelectedObj.SetActive(true);
        }
    }

    public void UnlockStick()
    {
        PlayerPrefs.SetInt(stickPrefab.gameObject.name, 1);
        Init();
    }

}
