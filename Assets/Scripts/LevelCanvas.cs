using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{
    public LevelProgress levelProgressBar;
    public Text curentScoreText;
    public Text currentGoldText;
    public Text currentLevelText;
    public GameObject[] healthObjs;
    public RectXformMover BossLevelPanel;
    public void UpdateHealth(int heartCount)
    {
        for (int i = 0; i < healthObjs.Length; i++)
        {
            if (i < heartCount)
            {
                healthObjs[i].SetActive(true);
            }
            else
            {
                healthObjs[i].SetActive(false);
            }
        }
    }


}
