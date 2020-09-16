using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera rayCam;

    private Rigidbody rb;
    private Vector2 movement;
    public float speed = 10;

    public bool mouseDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }


        if(mouseDown)
        {
            Ray mouseRay = rayCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(mouseRay,out RaycastHit hit))
            {
                Vector2 hitPosition = hit.point.ToXZ();
                Vector2 curr = transform.position.ToXZ();
                if (Vector2.Distance(hitPosition, curr) > 0.5f)
                {
                    movement = curr.DirectionTo(hitPosition);
                }
            }
        }
        else
        {
            movement = Vector2.zero;
        }
        /*
        //KEYS
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        */
    }

    void FixedUpdate()
    {
        rb.AddForce(speed * movement.ToXYZ(),ForceMode.Acceleration);
    }
}
