using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK.Setup;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelButton : MonoBehaviour
{

    public GameObject lockedImg;
    public Text levelText;
    private int buttonLevel;
    
    void Start()
    {
        int best = GameManager.Instance.bestLevel;
        buttonLevel = Convert.ToInt32(gameObject.name);
        levelText.text = gameObject.name;
        if (buttonLevel > best)
        {
            gameObject.GetComponent<Button>().interactable = false;
            lockedImg.SetActive(true);
        }
        else
        {
            lockedImg.SetActive(false);
        }

    }

    public void GoLevel()
    {
        GameManager.Instance.currentLevel = buttonLevel;
        SceneManager.LoadScene("Level" + buttonLevel.ToString());
    }
}
