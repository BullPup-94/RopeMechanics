using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint:MonoBehaviour
{
    
    public Rigidbody rigidBody;

    public float forceMultiplier;

    public void Shoot()
    {
        rigidBody.AddForce(forceMultiplier * Vector3.left, ForceMode.VelocityChange);
    }
}
