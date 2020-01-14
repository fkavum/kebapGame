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
        currentLevel = 1;
        bestScore = 66;
        gold = 15;
    }
}
