using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectMover : MonoBehaviour
{
   // starting position (typically offscreen)
	public Vector3 startPosition;

    // our onscreen position
	public Vector3 onscreenPosition;

    // our end position (typically offscreen again)
	public Vector3 endPosition;

    // time needed to move
	public float timeToMove = 1f;

    // are we currently moving?
	bool m_isMoving = false;


    // move the RectTransform
	void Move(Vector3 startPos, Vector3 endPos, float timeToMove,bool cutInput)
	{
		if (!m_isMoving) 
		{
			StartCoroutine (MoveRoutine (startPos, endPos, timeToMove,cutInput));
		}
	}

    // coroutine for movement; this is generic, just pass in a start position, end position and time to move
	IEnumerator MoveRoutine(Vector3 startPos, Vector3 endPos, float timeToMove,bool cutInput)
	{
		transform.position = startPos;
        // we have not reached our destination
		bool reachedDestination = false;

        // reset the amount of time that has passed
		float elapsedTime = 0f;

        // we are moving
		m_isMoving = true;

        // while we have not reached the destination...
		while (!reachedDestination) 
		{
            // ... check to see if we are close to the target position
			if (Vector3.Distance (transform.position, endPos) < 0.01f)
			{
				transform.position = endPos;
				reachedDestination = true;
				break;

			}
            // increment our elapsed time by the time for this frame
			elapsedTime += Time.deltaTime;

            // calculate the interpolation parameter
			float t = Mathf.Clamp (elapsedTime / timeToMove, 0f, 1f);
			t = t * t * t * (t * (t * 6 - 15) + 10);

            // linearly interpolate from the start to the end position
		
			transform.position = Vector3.Lerp (startPos, endPos, t);
              
			InputManager.Instance.touchAvaible = false;
            // wait one frame
			yield return null;

		}

		if (cutInput)
		{
			InputManager.Instance.touchAvaible = true;
			
		}
        // we are no longer moving
		m_isMoving = false;
	
	}

    // move from a starting position offscreen to a position onscreen
	public void MoveOn(bool cutInput = false)
	{
		Move (startPosition, onscreenPosition, timeToMove,cutInput);
	}

    // move from the position onscreen to an end position offscreen
	public void MoveOff(bool cutInput = false,bool destroy = false)
	{
		Move (onscreenPosition, endPosition, timeToMove,cutInput);
		if (destroy)
		{
			Destroy(gameObject,timeToMove);
		}
	}
}
