using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    #region Variables
    [Header("Renderer Settings")]
    [SerializeField] private UIGradient _skyGradient;

    public static Sky Instance;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Methods
    public void ChangeSky(SkyPreset preset)
    {
        return;
        StartCoroutine(Coroutine_ChangeSky(preset));
    }

    private IEnumerator Coroutine_ChangeSky(SkyPreset preset)
    {
        _skyGradient.m_color1 = preset.Top;
        _skyGradient.m_color2 = preset.Bottom;
        _skyGradient.enabled = false;
        _skyGradient.enabled = true;
        yield break;
    }
    #endregion

    #region Structs
    [System.Serializable]
    public struct SkyPreset
    {
        public Color Top;
        public Color Bottom;
    }
    #endregion
}
