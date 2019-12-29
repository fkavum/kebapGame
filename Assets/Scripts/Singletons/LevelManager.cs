using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
	bool m_isReadyToBegin = false;
	bool m_isGameOver = false;
    bool m_isReadyToReload = false;

   public override void Awake()
    {
        base.Awake();
    }
	void Start () 
	{
        // start the main game loop
		StartCoroutine ("ExecuteGameLoop");
	}

	IEnumerator ExecuteGameLoop()
	{
		yield return StartCoroutine ("StartGameRoutine");
		yield return StartCoroutine ("PlayGameRoutine");
		yield return StartCoroutine ("EndGameRoutine");
	}

    // switches ready to begin status to true
    public void BeginGame()
    {
        m_isReadyToBegin = true;

    }

    // coroutine for the level introduction
	IEnumerator StartGameRoutine()
	{
        // wait until the player is ready
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

}
