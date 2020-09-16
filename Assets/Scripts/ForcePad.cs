using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePad : MonoBehaviour
{
    public float forceMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Movement>()!=null)
        {
            StartCoroutine(ApplyDelayedForce(other.GetComponent<Rigidbody>(), 1));
        }
    }

    IEnumerator ApplyDelayedForce(Rigidbody rb,float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.AddForce(forceMultiplier * transform.up, ForceMode.Impulse);
    }
}
