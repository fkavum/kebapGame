using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Sword : MonoBehaviour
{
    
    /**
     * ROTATION PARAMETERS
     */
    private bool m_rotate = true;
    public float rotateSpeed = 10f;
    public bool isClockWise = true;
    private float rotationZ = 175f;

    /**
     * STABING PARAMETERS
     */
    // Sword has to be 0,0,0 position and place upsideDown
    public GameObject swordObject;
    public float stabTime = 2f;
    public float stabSize = 1f;


    public GameObject[] mealPoints;
    private int mealFound = 0;
    public float stabMealTime = 1f;
    
    private Rigidbody2D _rigidbody;
    private void Start()
    {

        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(RotatePlayer());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindCollectibles();
        }

    }
    
    private void FindCollectibles()
    {
        Debug.DrawRay(transform.position,transform.right,Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,  -transform.up,10f,1<<LayerMask.NameToLayer("RayCast"));
        if (hit.collider != null)
        {
            AnimateSword();
            MoveObject(hit);
        }
    }

    void MoveObject(RaycastHit2D hit)
    {
        GameObject obj = hit.collider.gameObject;
        obj.transform.parent = mealPoints[mealFound].transform;
        obj.layer = 1 << 0;
        mealFound++;
        StartCoroutine(MoveOrigin(obj));

    }
    
    IEnumerator MoveOrigin(GameObject obj)
    {
        float eclapsedTime = 0f;
        while (eclapsedTime < stabMealTime)
        {
            eclapsedTime += Time.deltaTime;
            float t = Mathf.Clamp(eclapsedTime / stabMealTime, 0f, 1f);
            t = Mathf.Sin(t * Mathf.PI * 0.5f);
            Vector3 startPoint = obj.transform.localPosition;

            obj.transform.localPosition = Vector3.Lerp(startPoint, Vector3.zero, t);
            yield return null;
        }

        obj.transform.localPosition = Vector3.zero;
        yield return null;
    }

    private void AnimateSword()
    {
        StartCoroutine(AnimateSwordCoroutine());
    }

    IEnumerator AnimateSwordCoroutine()
    {
        Vector3 startPosition = swordObject.transform.localPosition;
        Vector3 stabPosition = new Vector3(swordObject.transform.localPosition.x,
            swordObject.transform.localPosition.y - stabSize, swordObject.transform.localPosition.z);

        float stabInTime = stabTime / 2f;
        float elapsedTime = 0f;
        while (elapsedTime < stabInTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp(elapsedTime / stabInTime, 0f, 1f);
            t =  t*t*t*(t*(t*6 - 15) + 10);
            swordObject.transform.localPosition = Vector3.Lerp(startPosition, stabPosition, t);
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < stabInTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp(elapsedTime / stabInTime, 0f, 1f);
            t =  t*t*t*(t*(t*6 - 15) + 10);
            swordObject.transform.localPosition = Vector3.Lerp(stabPosition, startPosition, t);
            yield return null;
        }

        swordObject.transform.localPosition = startPosition;
    }

    IEnumerator RotatePlayer()
    {
        while (m_rotate)
        {
            if (rotationZ > 360.0f)
            {
                rotationZ -= 360f;
            }

            if (!isClockWise)
            {
                rotationZ += rotateSpeed * Time.deltaTime;
            }
            else
            {
                rotationZ -= rotateSpeed * Time.deltaTime;
            }

            transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
            yield return null;
        }

        yield return null;
    }
}