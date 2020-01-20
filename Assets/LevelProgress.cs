using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelProgress : MonoBehaviour
{
    private Slider _loader;

    private void Start()
    {
        _loader = GetComponent<Slider>();
    }

    public void ChangeLevelProgressValue(float endValue, float slideTime)
    {
        _loader.DOValue(endValue, slideTime);
    }
}
