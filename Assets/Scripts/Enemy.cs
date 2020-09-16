using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float forceMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collector>()!=null)
        {
            gameObject.SetActive(false);
        }
        else if(other.GetComponent<Movement>()!=null)
        {
            other.GetComponent<Rigidbody>().AddForce(forceMultiplier * (other.transform.position - transform.position).normalized, ForceMode.Impulse);
        }
    }
}
