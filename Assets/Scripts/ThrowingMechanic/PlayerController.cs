using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public ControlPoint current;
    public Camera rayCam;
    public LayerMask mousePointMask;
    private bool mouseDown;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            current.rigidBody.isKinematic = false;
            current.rigidBody.useGravity = true;
            current.Shoot();
        }

        if(mouseDown)
        {
            current.transform.eulerAngles = Vector3.zero;
            Ray mouseRay = rayCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, mousePointMask))
            {
                Vector3 hitPoint = hit.point;
                hitPoint.z = 0;
                current.gameObject.transform.position = hitPoint;
                current.rigidBody.isKinematic = true;
                current.rigidBody.useGravity = false;
            }
        }
    }
}
