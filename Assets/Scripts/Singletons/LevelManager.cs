using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
	bool m_isReadyToBegin = false;
	bool m_isGameOver = false;
    bool m_isReadyToReload = false;
    
    
    private int currentHealth;


    [Header("Should fill in the inspector")]
    public int levelTotalStep;
    public int levelCurrentStep;
    public LevelCanvas LevelCanvas;
    public int initialHealth;
    
   public override void Awake()
    {
        base.Awake();
    }
	void Start () 
	{
		StartCoroutine ("ExecuteGameLoop");
	}

	IEnumerator ExecuteGameLoop()
	{
		yield return StartCoroutine ("StartGameRoutine");
		yield return StartCoroutine ("PlayGameRoutine");
		yield return StartCoroutine ("EndGameRoutine");
	}

    // coroutine for the level introduction
	IEnumerator StartGameRoutine()
	{
		currentHealth = initialHealth;
		LevelCanvas.UpdateHealth(currentHealth);
		
		while (!m_isReadyToBegin) 
		{
			yield return null;
		}
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
        // wait until read to reload
        while (!m_isReadyToReload)
        {
            yield return null;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
	}
	
	public void decreaseHealth()
	{
		currentHealth -= 1;
		LevelCanvas.UpdateHealth(currentHealth);

		if (currentHealth <= 0)
		{
			m_isGameOver = true;
		}
		
	}    

}
