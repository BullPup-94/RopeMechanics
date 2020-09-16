using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDragDropHandler
{
    void PointerDownHandler(Vector3 hitPosition);
    void PointerDragHandler(Vector3 hitPosition);
    void PointerUpHandler();
    void ValidateDropHandler(bool isValidDrop,RaycastHit dropCoordinates);
    void OnSuccessfulDropHandler();
    void OnDropFailHandler();

}
