using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private string targetTag;


    private bool isDragged;
    private GameObject draggedObject;

    private void Update()
    {
        if (InputManager.Instance.IsPressed() && !isDragged)
        {
            draggedObject = CollisionCheck();

            if (draggedObject == null)
                return;

            isDragged = true;
        }

        if (InputManager.Instance.IsPressed() && isDragged)
        {
            DragObject();
        }

        if (!InputManager.Instance.IsPressed() && isDragged)
        {
            isDragged = false;
            SetWallFinalPosition();
            draggedObject = null;
        }
    }

    private GameObject CollisionCheck()
    {
        RaycastHit hit;
        Vector3 mousePosition = InputManager.Instance.GetMousePosition();
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag.Equals(targetTag))
                return hit.transform.gameObject;

        }

        return null;
    }

    private void DragObject()
    {
        Vector3 finalPosition = mainCamera.ScreenToWorldPoint(InputManager.Instance.GetMousePosition());
        finalPosition.x = finalPosition.x > 3.5 ? 3.5f : finalPosition.x;
        finalPosition.x = finalPosition.x < -3.5 ? -3.5f : finalPosition.x;

        finalPosition.y = finalPosition.y > -0.5 ? -0.5f : finalPosition.y;
        finalPosition.y = finalPosition.y < -7.5 ? -7.5f : finalPosition.y;

        finalPosition.z = 0f;
        draggedObject.transform.position = finalPosition;
    }

    private void SetWallFinalPosition()
    {
        Vector3 finalPosition = new Vector3(draggedObject.transform.position.x, draggedObject.transform.position.y, -2f);

        float x = (int)finalPosition.x;
        x += finalPosition.x < 0 ? -0.5f : 0.5f;

        float y = (int)finalPosition.y;
        y += finalPosition.y < 0 ? -0.5f : 0.5f;

        finalPosition.x = x;
        finalPosition.y = y;

        draggedObject.transform.position = finalPosition;
    }

    public void SetDraggedObject(GameObject draggedObject)
    {
        this.draggedObject = draggedObject;
        isDragged = true;
    }

    public bool GetIsDragged()
    {
        return isDragged;
    }
}
