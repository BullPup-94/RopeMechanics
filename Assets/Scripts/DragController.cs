using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragController : MonoBehaviour
{

    [Header("Layer Masks")]
    [SerializeField]
    private LayerMask pointerDownMask;
    [SerializeField]
    private LayerMask pointerDragMask;
    [SerializeField]
    private LayerMask pointerDropMask;

    [Header("Ray Casting Camera")]
    [SerializeField]
    private Camera rayCam;


    [Header("Paramaeters")]
    public bool activate;

    
    public static Action<Vector3> PointerDownHandle;
    public static Action<Vector3> PointerDragHandle;
    public static Action PointerUpHandle;
    public static Action OnSuccessfulDrop;
    public static Action OnDropFail;

    public static Action<bool,RaycastHit> ValidateDropHandle;


    private bool mouseDown;
    private bool objectDragged;

    // Start is called before the first frame update
    void Start()
    {
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activate) return;

        if(Input.GetMouseButtonDown(0) && !mouseDown)
        {
            mouseDown = true;
            Ray mouseRay = rayCam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(mouseRay,out RaycastHit hit,Mathf.Infinity,pointerDownMask))
            {
                Debug.Log("Drag object detected");
                objectDragged = true;
                PointerDownHandle?.Invoke(hit.point);
            }
        }
        else if(Input.GetMouseButtonUp(0) && mouseDown)
        {
            mouseDown = false;

            if (objectDragged)
            {
                Ray mouseRay = rayCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, pointerDropMask))
                {
                    OnSuccessfulDrop?.Invoke();
                }
                else
                {
                    OnDropFail?.Invoke();
                }
                PointerUpHandle?.Invoke();
            }
            objectDragged = false;
        }
        
        if(mouseDown && objectDragged)
        {
            Ray mouseRay = rayCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit dragHit, Mathf.Infinity, pointerDragMask))
            {
                PointerDragHandle?.Invoke(dragHit.point);
            }
            RaycastHit dropHit;
            if (Physics.Raycast(mouseRay, out dropHit, Mathf.Infinity, pointerDropMask))
            {
                ValidateDropHandle?.Invoke(true,dropHit);
            }
            else
            {
                ValidateDropHandle?.Invoke(false,dropHit);
            }
        }
    }
}
