using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject customizePanel;
    
    public Text bestScoreText;
    public Text currentGoldText;
    public Text currentLevelText;

    private void Start()
    {
        bestScoreText.text = "Best: " + GameManager.Instance.bestScore.ToString();
        currentGoldText.text = GameManager.Instance.gold.ToString();
        currentLevelText.text = "Level " + GameManager.Instance.currentLevel.ToString();
    }

    public  void StartGameButton()
   {
      SceneManager.LoadScene("mvpGame");
   }

  public void OpenCustomizePanel()
  {
      customizePanel.SetActive(true);
  }
  
  public void CloseCustomizePanel()
  {
      customizePanel.SetActive(false);
  }
}
