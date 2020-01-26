using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// the GameManager is the master controller for the GamePlay

public class GameManager : Singleton<GameManager>
{

    public int bestScore;
    public int bestLevel;
    public int gold;
    public int currentScore;
    public GameObject selectedSwordPrefab;
    public int currentLevel;
    
    
    public int buySwordPrice;
    public int levelCompleteGold;

    public bool vibrateOn;
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        currentScore = 0;
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            bestScore = 0;
        }
        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level",1);
            PlayerPrefs.SetInt("BestLevel",1);
            currentLevel = 1;
        }
        if (PlayerPrefs.HasKey("Gold"))
        {
            gold = PlayerPrefs.GetInt("Gold");
        }
        else
        {
            gold = 370;
        }
        if (PlayerPrefs.HasKey("BestLevel"))
        {
            bestLevel = PlayerPrefs.GetInt("BestLevel");
        }
        else
        {
            bestLevel = currentLevel;
        }
        if (!PlayerPrefs.HasKey(selectedSwordPrefab.gameObject.name))
        {
            PlayerPrefs.SetInt(selectedSwordPrefab.gameObject.name,1);
        }

        buySwordPrice = 100;
        // when you change this. Change also win panel.
        levelCompleteGold = 10;

        vibrateOn = true;
    }

    public void GoNextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("Level",currentLevel);

        if (currentLevel > bestLevel)
        {
            PlayerPrefs.SetInt("BestLevel",currentLevel);
            bestLevel = currentLevel;
        }
        
        SceneManager.LoadScene("Level"+GameManager.Instance.currentLevel.ToString());
    }

    public void AddGold(int goldValue)
    {
        gold += goldValue;
        PlayerPrefs.SetInt("Gold",gold);        
    }
    
    public void SellGold(int goldValue)
    {
        gold -= goldValue;
        PlayerPrefs.SetInt("Gold",gold);        
    }

    public void UpdateBestScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore",bestScore);
        }
    }
    
}
