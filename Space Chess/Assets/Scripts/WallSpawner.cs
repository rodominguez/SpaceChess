using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject wallToSpawn;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private DragAndDrop dragAndDrop;
    [SerializeField] private Transform parent;

    [SerializeField] private bool isHorizontal;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed && !dragAndDrop.GetIsDragged() && CollisionCheck())
        {
            SpawnWall();
        }
    }

    private bool CollisionCheck()
    {
        RaycastHit hit;
        Vector3 mousePosition = ConvertMousePosition();
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (IsWallAvailable() && hit.transform.gameObject.Equals(gameObject))
                return true;

        }

        return false;
    }

    private void SpawnWall()
    {
        SubstractWall();
        GameObject spawn = Instantiate(wallToSpawn);
        spawn.transform.parent = parent;
        dragAndDrop.SetDraggedObject(spawn);
    }

    private Vector3 ConvertMousePosition()
    {
        return new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 0f);
    }

    private void SubstractWall()
    {
        if (isHorizontal)
        {
            levelManager.GetCurrentLevel().SubstractHorizontalWalls();
        }
        else
        {
            levelManager.GetCurrentLevel().SubstractVerticalWalls();
        }
    }

    private bool IsWallAvailable()
    {
        if (levelManager.GetCurrentLevel() == null) return false;
        if (isHorizontal)
        {
            return levelManager.GetCurrentLevel().GetCurrentHorizontalWalls() > 0;
        }
        return levelManager.GetCurrentLevel().GetCurrentVerticalWalls() > 0;
    }
}
