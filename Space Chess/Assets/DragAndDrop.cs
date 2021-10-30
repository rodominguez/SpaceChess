using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;


    private bool isDragged;
    private GameObject draggedObject;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed && !isDragged)
        {
            draggedObject = CollisionCheck();

            if (draggedObject == null)
                return;
            
            isDragged = true;
        }
        
        if (Mouse.current.leftButton.isPressed && isDragged)
        {
            DragObject();
        }

        if (!Mouse.current.leftButton.isPressed)
        {
            isDragged = false;
            draggedObject = null;
        }
    }

    private GameObject CollisionCheck()
    {
        RaycastHit hit;
        Vector3 mousePosition = ConvertMousePosition();
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject.tag);

            if (hit.transform.gameObject.tag.Equals("Wall"))
                return hit.transform.gameObject;
       
        }

        return null;
    }

    private void DragObject()
    {
        Vector3 finalPosition = mainCamera.ScreenToWorldPoint(ConvertMousePosition());
        finalPosition.z = -2f;
        draggedObject.transform.position = finalPosition;
    }

    private Vector3 ConvertMousePosition()
    {
        return new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 0f);
    }
}
