using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMouseFollower : MonoBehaviour,IDragDropHandler
{

    public bool lockOnDrop;
    public bool initialPositionOnDropFail;

    private Vector3 initialPosition;

    protected bool goToMouse;
    protected Vector3 mouseCoordinates;
    [SerializeField]
    protected Vector3 mouseOffsets;

    [SerializeField]
    [Range(0f, 1f)]
    protected float smoothingTime;
    protected Vector3 smoothingVelocity;

    [SerializeField]
    protected float invalidDropY=0f;
    
    public bool validDrop;
    protected Vector3 dropCoordinates;
    [SerializeField]
    protected Vector3 dropOffsets;
    
    private bool activate;
    private bool dropUnsuccessful;

    public virtual void PointerDownHandler(Vector3 hitPosition)
    {
        //Debug.Log($"Pointer down: {hitPosition}");
        goToMouse = true;
        mouseCoordinates = hitPosition;
    }

    public virtual void PointerDragHandler(Vector3 hitPosition)
    {
        //Debug.Log($"Pointer drag: {hitPosition}");
        mouseCoordinates = hitPosition;
    }

    public virtual void PointerUpHandler()
    {
        //Debug.Log($"Pointer Up");
        goToMouse = false;
    }

    public virtual void ValidateDropHandler(bool isValidDrop, RaycastHit drophit)
    {
        //Debug.Log($"Valid drop: {isValidDrop} at {dropCoordinates}");
        validDrop = isValidDrop;
        if (!validDrop) return;
        dropCoordinates = drophit.transform.position;
    }

    public virtual void OnSuccessfulDropHandler()
    {
        if(lockOnDrop)
        {
            activate = false;
        }
    }

    public virtual void OnDropFailHandler()
    {
        if(initialPositionOnDropFail)
        {
            dropUnsuccessful = true;
        }
    }


    protected virtual void Start()
    {
        DragController.PointerDownHandle += PointerDownHandler;
        DragController.PointerDragHandle += PointerDragHandler;
        DragController.PointerUpHandle += PointerUpHandler;
        DragController.ValidateDropHandle += ValidateDropHandler;
        DragController.OnSuccessfulDrop+=OnSuccessfulDropHandler ;
        DragController.OnDropFail += OnDropFailHandler;
        initialPosition = transform.position;
        dropUnsuccessful = false;
        activate = true;
    }
    

    protected void OnDestroy()
    {
        DragController.PointerDownHandle -= PointerDownHandler;
        DragController.PointerDragHandle -= PointerDragHandler;
        DragController.PointerUpHandle -= PointerUpHandler;
        DragController.ValidateDropHandle -= ValidateDropHandler;
        DragController.OnSuccessfulDrop -= OnSuccessfulDropHandler;
        DragController.OnDropFail -= OnDropFailHandler;
    }


    protected virtual void Update()
    {
        FollowMouse();
    }

    protected void FollowMouse()
    {
        if (!activate) return;
        if(dropUnsuccessful)
        {
            transform.position = Vector3.SmoothDamp(transform.position, initialPosition, ref smoothingVelocity, smoothingTime);
            if(Vector3.Distance(transform.position,initialPosition)<0.1f)
            {
                dropUnsuccessful = false;
            }
            return;
        }

        if (validDrop)
        {
            transform.position = Vector3.SmoothDamp(transform.position, dropCoordinates + dropOffsets, ref smoothingVelocity, smoothingTime);
            return;
        }

        if (goToMouse)
        {
            Vector3 target = mouseCoordinates + mouseOffsets;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref smoothingVelocity, smoothingTime);
        }
        else
        {
            Vector3 target = transform.position;
            target.y = invalidDropY;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref smoothingVelocity, smoothingTime);
        }
    }
}
