using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public Vector3 zeroPosition;
    public Vector3 endPosition;
    public GameObject loadBar;
    
    public void ChangeLevelProgressValue(float endValue,float slideTime)
    {
        StartCoroutine(ChangeLevelProgressValueCoroutine(endValue,slideTime));
    }
    
    // coroutine for movement; this is generic, just pass in a start position, end position and time to move
    IEnumerator ChangeLevelProgressValueCoroutine(float endValue,float slideTime)
    {
        RectTransform rt = loadBar.GetComponent<RectTransform>();
        
        Vector3 firstPos = rt.localPosition;

        Vector3 endPos = (endPosition - zeroPosition) * endValue + zeroPosition;

        // we have not reached our destination
        bool reachedDestination = false;

        // reset the amount of time that has passed
        float elapsedTime = 0f;

        // while we have not reached the destination...
        while (!reachedDestination) 
        {
            // ... check to see if we are close to the target position
            if (Vector3.Distance(endPos , rt.localPosition) < 0.01f)
            {
                reachedDestination = true;
                break;
            }
            // increment our elapsed time by the time for this frame
            elapsedTime += Time.deltaTime;

            // calculate the interpolation parameter
            float t = Mathf.Clamp (elapsedTime / slideTime, 0f, 1f);
            t = t * t * t * (t * (t * 6 - 15) + 10);

            // linearly interpolate from the start to the end position
            if (rt != null)
            {
                rt.localPosition = Vector3.Lerp (firstPos, endPos, t);
              
            }

            // wait one frame
            yield return null;

        }
        rt.localPosition = endPos; 
	
    }
    
}
