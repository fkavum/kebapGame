using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTip : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fruit")
        {
            other.gameObject.GetComponent<Fruit>().PlayStabParticleEffect();
        }
    }
}