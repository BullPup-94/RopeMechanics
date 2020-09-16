using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingCube : MonoBehaviour
{

    public Vector3 forceDirection;
    public float forceMultiplier;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyForce()
    {
        rb.AddForce(forceMultiplier * forceDirection, ForceMode.VelocityChange);
    }
}
