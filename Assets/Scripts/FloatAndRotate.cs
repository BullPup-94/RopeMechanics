using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    public bool activate;
    public bool canFloat;
    public bool canRotate;

    float counter;
    [Range(0f,1f)]
    public float amplitude;
    public float frequency;

    public Vector3 basePosition;
    public bool useCurrent;
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        if(useCurrent)
        {
            basePosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!activate) return;
        if(canFloat) FloatAround();
        if(canRotate) RotateObject();

    }


    void FloatAround()
    {
        counter += frequency*Time.deltaTime;
        transform.position = basePosition + amplitude * Mathf.Sin(counter) * Vector3.up;
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime,Space.World);
    }
}
