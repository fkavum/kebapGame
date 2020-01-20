using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GA_Analytics : MonoBehaviour
{
    #region UnityMethods
    private void Awake()
    {
        GameAnalytics.Initialize();
    }
    #endregion
}
