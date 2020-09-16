using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public MovingCube leftControl;
    public MovingCube rightControl;

    private MovingCube current;

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
        }

        if(mouseDown)
        {
            if(Input.mousePosition.x >= Screen.width/2)
            {
                current = rightControl;
            }
            else
            {
                current = leftControl;
            }
        }
    }

    private void FixedUpdate()
    {
        if (mouseDown)
        {
            current.ApplyForce();
        }
    }
}
