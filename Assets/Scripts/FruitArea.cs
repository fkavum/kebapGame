using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitArea : MonoBehaviour
{
    
    /**
     * ROTATION PARAMETERS
     */
    public bool m_rotate = true;
    public float rotateSpeed = 10f;
    public bool isClockWise = true;
    private float rotationZ = 175f;

    public int fruitCount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotatePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
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
