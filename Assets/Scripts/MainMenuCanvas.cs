using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject customizePanel;
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
