using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject stabparticleEffect;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == LayerMask.NameToLayer("RayCast"))
        {
            gameObject.transform.RotateAround (Vector3.up, Time.deltaTime);
        }
    }

    public void PlayStabParticleEffect()
    {
        GameObject particleObj = Instantiate(stabparticleEffect, transform.position, Quaternion.identity);
        particleObj.transform.parent = transform;
        particleObj.transform.localScale = new Vector3(1f,1f,1f);
        Destroy(particleObj,1f);
        
    }
    
}
