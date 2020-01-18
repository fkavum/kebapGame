using System.Collections;
using System.Collections.Generic;
using Infated.Tools;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    bool m_isReadyToBegin = false;
    bool m_isGameOver = false;
    bool m_isReadyToReload = false;

    private bool m_isWinner = false;
    private bool m_isLose = false;

    [Header("Should fill in the inspector")]
    public LevelCanvas LevelCanvas;

    public int initialHealth;

    private Sword m_sword;
    private FruitArea m_fruitArea;
    private int m_currentHealth;
    private LevelBehaviour m_levelBehaviour;
    private int m_stepCount;
    private int m_currentStep;

    public bool IsGameOver
    {
        get => m_isGameOver;
        set => m_isGameOver = value;
    }

    private int m_currentCollectedFruit;
    private int m_fruitToCollect;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        m_levelBehaviour = gameObject.GetComponent<LevelBehaviour>();
        m_stepCount = m_levelBehaviour.stepList.Count;
        StartCoroutine("ExecuteGameLoop");

        Camera.main.gameObject.AddComponent<CameraShake>();
        Camera.main.gameObject.GetComponent<CameraShake>().shakeAmount = 0.08f;
    }

    IEnumerator ExecuteGameLoop()
    {
        yield return StartCoroutine("StartGameRoutine");
        yield return StartCoroutine("PlayGameRoutine");
        yield return StartCoroutine("EndGameRoutine");
    }

    // coroutine for the level introduction
    IEnumerator StartGameRoutine()
    {
        InitLevel();
        m_isReadyToBegin = true;
        while (!m_isReadyToBegin)
        {
            yield return null;
        }
    }

    void InitLevel()
    {
        m_currentHealth = initialHealth;
        LevelCanvas.UpdateHealth(m_currentHealth);
        m_currentStep = 0;
        initTheStep();
        InitUIElements();
        SoundManager.Instance.StopLoopingSounds();
        SoundManager.Instance.PlayRandomMusic();
    }

    private void InitUIElements()
    {
        LevelCanvas.curentScoreText.text = GameManager.Instance.currentScore.ToString();
        LevelCanvas.currentGoldText.text = GameManager.Instance.gold.ToString();
        LevelCanvas.currentLevelText.text = "Level " + GameManager.Instance.currentLevel.ToString();
    }


    private void InitFruits(int step, bool isBossStep)
    {
        m_fruitArea = m_levelBehaviour.InitFruit(step,isBossStep);
        m_fruitToCollect = m_fruitArea.fruitCount;
        m_currentCollectedFruit = 0;
    }

    private void InitSword()
    {
        GameObject swordObj = Instantiate(GameManager.Instance.selectedSwordPrefab, Vector3.zero, Quaternion.identity);
        m_sword = swordObj.GetComponent<Sword>();
        m_sword.GetComponent<GameobjectMover>().MoveOn(true);
        m_sword.SetMealPoints(m_fruitArea.fruitCount);
    }

    private void initTheStep()
    {
        bool isBossStep = false;
        LevelCanvas.levelProgressBar.ChangeLevelProgressValue((float) m_currentStep / (float) m_stepCount, 1f);
        
        InputManager.Instance.touchAvaible = false;
        if (m_currentStep == m_stepCount)
        {
            m_isGameOver = true;
            m_isWinner = true;
            //Todo: Score manager needed.
            GameManager.Instance.AddGold(5);
            return;
        }

        if (m_currentStep + 1 == m_stepCount)
        {
            isBossStep = true;
        }

        if (m_sword != null)
        {
            m_sword.gameObject.GetComponent<GameobjectMover>().MoveOff(false,true);
        }

        if (m_fruitArea != null)
        {
            m_fruitArea.gameObject.GetComponent<GameobjectMover>().MoveOff(false,true);
        }

        StartCoroutine(InitTheStepCoroutine(isBossStep));
    }

    IEnumerator InitTheStepCoroutine(bool isBossStep)
    {
        if (isBossStep)
        {
            LevelCanvas.BossLevelPanel.gameObject.SetActive(true);
            LevelCanvas.BossLevelPanel.MoveOn();
            yield return new WaitForSeconds(1f);
            LevelCanvas.BossLevelPanel.MoveOff();
        }
        
        InitFruits(m_currentStep,isBossStep);
        InitSword();
        m_levelBehaviour.StartCoroutines(m_currentStep, m_sword, m_fruitArea);
        yield return null;
    }
    
    // coroutine for game play
    IEnumerator PlayGameRoutine()
    {
        while (!m_isGameOver)
        {
            yield return null;
        }
    }

    // coroutine for the end of the level
    IEnumerator EndGameRoutine()
    {
        m_isReadyToReload = true;

        if (m_isWinner)
        {
            StartCoroutine(GoNextLevel());
        }

        // wait until read to reload
        while (!m_isReadyToReload)
        {
            yield return null;
        }

        if (!m_isWinner)
        {
            yield return new WaitForSeconds(0.5f);
            GameManager.Instance.UpdateBestScore();
            SceneManager.LoadScene("MainMenu");  
        }
    
    }


    IEnumerator GoNextLevel()
    {

        yield return new WaitForSeconds(1f);
        GameManager.Instance.GoNextLevel();
        yield return null;
    }

    public void decreaseHealth()
    {
        m_currentHealth -= 1;
        LevelCanvas.UpdateHealth(m_currentHealth);

        if (m_currentHealth <= 0)
        {
            m_isGameOver = true;
        }
    }

    public void fruitCollected()
    {
        m_currentCollectedFruit += 1;

        //TODO: Score manager needed.
        GameManager.Instance.currentScore++;
        LevelCanvas.curentScoreText.text = GameManager.Instance.currentScore.ToString();
        
        if (m_fruitToCollect <= m_currentCollectedFruit)
        {
            m_currentStep += 1;

            initTheStep();
        }
    }
    
    
  
}