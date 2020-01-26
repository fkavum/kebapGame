using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouLosePanel : MonoBehaviour
{
    public Text best;
    public Text current;

    private void OnEnable()
    {
        best.text = "BEST: "+ GameManager.Instance.bestScore.ToString();
        current.text = "SCORE: "+GameManager.Instance.currentScore.ToString();
    }
}
