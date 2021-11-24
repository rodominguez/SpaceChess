using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawn : MonoBehaviour
{

    [SerializeField] private Transform spawn;

    [SerializeField] private Vector3 northEast;
    [SerializeField] private Vector3 southEast;
    [SerializeField] private Vector3 southWest;
    [SerializeField] private Vector3 northWest;
    [SerializeField] private ShipMovement shipMovement;

    bool isDown;
    bool isLeft;

    private void Update()
    {
        if (shipMovement.GetIsShoot()) return;
        if (InputManager.Instance.GetSwitchAngleHorizontal() == 1)
        {
            if (!isDown)
                spawn.eulerAngles = northEast;
            else
                spawn.eulerAngles = southEast;
            isLeft = false;
        }
        else if (InputManager.Instance.GetSwitchAngleHorizontal() == -1)
        {
            if (!isDown)
                spawn.eulerAngles = northWest;
            else
                spawn.eulerAngles = southWest;
            isLeft = true;
        }

        if (InputManager.Instance.GetSwitchAngleVertical() == 1)
        {
            if (!isLeft)
                spawn.eulerAngles = northEast;
            else
                spawn.eulerAngles = northWest;
            isDown = false;
        }
        else if (InputManager.Instance.GetSwitchAngleVertical() == -1)
        {
            if (!isLeft)
                spawn.eulerAngles = southEast;
            else
                spawn.eulerAngles = southWest;
            isDown = true;
        }  
    }
}
