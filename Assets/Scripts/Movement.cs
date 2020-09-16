using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera rayCam;
    [Range(0.1f, 2f)]
    public float movementThresholdDistance = 0.5f;
    public float speed = 10;

    private Rigidbody rb;
    private Vector2 movement;
    private bool mouseDown;
    private bool canMove;
    
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
                if (Vector2.Distance(hitPosition, curr) > movementThresholdDistance)
                {
                    canMove = true;
                    movement = curr.DirectionTo(hitPosition);
                }
                else
                {
                    canMove = false;
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
        if (canMove)
        {
            rb.AddForce(speed * movement.ToXYZ(), ForceMode.Acceleration);
        }
        else
        {
            rb.velocity = rb.velocity.With(x: 0, z: 0);
        }
    }
}
