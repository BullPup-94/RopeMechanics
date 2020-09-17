using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public Vector3 PrevMousePos;
    public Transform CharacterTransform;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PrevMousePos = Input.mousePosition;
        }
        else
         if(Input.GetMouseButton(0))
        {
            if(Input.mousePosition != PrevMousePos)
            {
                float XDelta = Input.mousePosition.x - PrevMousePos.x;
                float ZDelta = Input.mousePosition.y - PrevMousePos.y;
                if(XDelta > 1 || ZDelta > 1)
                    CharacterTransform.position = new Vector3((CharacterTransform.position.x + XDelta)*Time.deltaTime, CharacterTransform.position.y, (CharacterTransform.position.z + ZDelta) * Time.deltaTime);
            }
            else
            PrevMousePos = Input.mousePosition;
        }
    }
}
