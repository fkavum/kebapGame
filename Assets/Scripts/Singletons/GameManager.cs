using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// the GameManager is the master controller for the GamePlay

public class GameManager : Singleton<GameManager>
{

    public int bestScore;
    public int gold;
    public int currentScore;
    public GameObject selectedSwordPrefab;
    public int currentLevel;
    
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
            currentLevel = 1;
        }
        if (PlayerPrefs.HasKey("Gold"))
        {
            gold = PlayerPrefs.GetInt("Gold");
        }
        else
        {
            gold = 15;
        }
    }

    public void GoNextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("Level",currentLevel);
        SceneManager.LoadScene("Level"+GameManager.Instance.currentLevel.ToString());
    }

    public void AddGold(int goldValue)
    {
        gold += goldValue;
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
