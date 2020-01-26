using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK.Setup;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject customizePanel;
    
    public Text bestScoreText;
    public Text currentGoldText;
    public Text currentLevelText;
    public Text currentGoldTextCustomize;
    public Text buySwordPriceText;

    private GameObject m_mainMenuSword;

    public GameObject soundOnButton;
    public GameObject soundOffButton;
    
    private void Start()
    {
        customizePanel.SetActive(true);
        bestScoreText.text = "Best: " + GameManager.Instance.bestScore.ToString();
        currentGoldText.text = GameManager.Instance.gold.ToString();
        currentGoldTextCustomize.text = GameManager.Instance.gold.ToString();
        buySwordPriceText.text = GameManager.Instance.buySwordPrice.ToString();
        currentLevelText.text = "Level " + GameManager.Instance.currentLevel.ToString();
        
        InitMainMenuSword();
        
        SoundManager.Instance.PlayRandomMusic();
        if (PlayerPrefs.HasKey("MusicOn"))
        {
            if (PlayerPrefs.GetInt("MusicOn") == 1)
            {
                YesSoundButton();
            }
            else
            {
                NoSoundButton();
            }
        }
        
        customizePanel.GetComponent<CustomizePanel>().UnSelectAllButtons();
        customizePanel.SetActive(false);
        
    }

    private void InitMainMenuSword()
    {
        m_mainMenuSword = Instantiate(GameManager.Instance.selectedSwordPrefab, new Vector3(0,1f,0), Quaternion.identity);
    }

    public  void StartGameButton()
   {
      SceneManager.LoadScene("Level" + GameManager.Instance.currentLevel.ToString());
      GameManager.Instance.currentScore = 0;
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

  public void ReverseTime()
  {
      PlayerPrefs.DeleteAll();
  }

  public void NoSoundButton()
  {
      SoundManager.Instance.NoSoundVolume();
      soundOnButton.SetActive(true);
      soundOffButton.SetActive(false);
      PlayerPrefs.SetInt("MusicOn",0);
  }
  public void YesSoundButton()
  {
      SoundManager.Instance.YesSoundVolume();
      soundOnButton.SetActive(false);
      soundOffButton.SetActive(true);
      PlayerPrefs.SetInt("MusicOn",1);
  }

  public void BuySwordButton()
  {
      if (GameManager.Instance.gold >= GameManager.Instance.buySwordPrice)
      {
          customizePanel.GetComponent<CustomizePanel>().UnlockRandom();
          GameManager.Instance.SellGold(GameManager.Instance.buySwordPrice);
          currentGoldText.text = GameManager.Instance.gold.ToString();
          currentGoldTextCustomize.text = GameManager.Instance.gold.ToString();
      }
  }
  
}
