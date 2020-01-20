using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GA_Analytics : MonoBehaviour
{
    static public GA_Analytics Instance;
    #region UnityMethods

    private void Awake()
    {
        GameAnalytics.Initialize();
        Instance = this;

    }

    #endregion
    public void SendWin3Level(int Level)
    {
        //GameAnalytics.NewDesignEvent($"LevelWin3starsWin{Level}");
    }
    public void SendWinLevel(int Level)
    {
        //GameAnalytics.NewDesignEvent($"LevelWin{Level}");
    }
}
