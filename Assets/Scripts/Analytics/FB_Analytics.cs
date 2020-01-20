using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

public class FB_Analytics : MonoBehaviour
{
    #region UnityMethods
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
            Start();
    }

    private void Start()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }
    #endregion

    #region Callbacks
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }
    #endregion
}
