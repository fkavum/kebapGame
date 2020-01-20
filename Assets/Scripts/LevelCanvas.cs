using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{
    private LevelProgress _levelProgressBar;
    public LevelProgress LevelProgressBar
    {
        get
        {
            if (!_levelProgressBar)
                _levelProgressBar = FindObjectOfType<LevelProgress>();

            return _levelProgressBar;
        }
    }

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
