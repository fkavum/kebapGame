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

    private GameObject m_mainMenuSword;

    private void Start()
    {
        bestScoreText.text = "Best: " + GameManager.Instance.bestScore.ToString();
        currentGoldText.text = GameManager.Instance.gold.ToString();
        currentLevelText.text = "Level " + GameManager.Instance.currentLevel.ToString();

        InitMainMenuSword();
    }

    private void InitMainMenuSword()
    {
        m_mainMenuSword = Instantiate(GameManager.Instance.selectedSwordPrefab, new Vector3(0,1f,0), Quaternion.identity);
    }

    public  void StartGameButton()
   {
      SceneManager.LoadScene("Level1");
   }

  public void OpenCustomizePanel()
  {
      customizePanel.SetActive(true);
  }
  
  public void CloseCustomizePanel()
  {
      customizePanel.SetActive(false);
      Destroy(m_mainMenuSword);
      m_mainMenuSword = Instantiate(GameManager.Instance.selectedSwordPrefab, new Vector3(0,1f,0), Quaternion.identity);
  }
}
