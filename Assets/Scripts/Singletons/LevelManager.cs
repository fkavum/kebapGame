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

    }

    private void InitFruits(int step)
    {
        m_fruitArea = m_levelBehaviour.InitFruit(step);
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
        InputManager.Instance.touchAvaible = false;
        if (m_currentStep == m_stepCount)
        {
            m_isGameOver = true;
            m_isWinner = true;
            return;
        }

        if (m_sword != null)
        {
            m_sword.gameObject.GetComponent<GameobjectMover>().MoveOff(false,true);
        }

        if (m_fruitArea != null)
        {
            m_fruitArea.gameObject.GetComponent<GameobjectMover>().MoveOff(false,true);
        }

        InitFruits(m_currentStep);
        InitSword();
        m_levelBehaviour.StartCoroutines(m_currentStep, m_sword, m_fruitArea);
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
            Debug.Log("You win the game!");
        }

        // wait until read to reload
        while (!m_isReadyToReload)
        {
            yield return null;
        }

        SceneManager.LoadScene("MainMenu");
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

        if (m_fruitToCollect <= m_currentCollectedFruit)
        {
            m_currentStep += 1;

            initTheStep();
        }
    }
}