using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    PlayerControls controls;

    private float timeToFire = 0f;

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    public float GetSwitchAngleHorizontal()
    {
        return controls.Gameplay.switchAngleHorizontal.ReadValue<float>();
    }

    public float GetSwitchAngleVertical()
    {
        return controls.Gameplay.switchAngleVertical.ReadValue<float>();
    }

    public bool GetShoot(float increment)
    {
        if (controls.Gameplay.shoot.ReadValue<float>() > 0.1 && Time.time >= timeToFire)
        {
            timeToFire = Time.time + increment;
            return true;
        }
        return false;
    }

    public float GetShipMovementHorizontal()
    {
        if (controls.Gameplay.moveRight.triggered)
            return 1;
        else if (controls.Gameplay.moveLeft.triggered)
            return -1;
        return 0;
    }

    public float GetShipMovementVertical()
    {
        if (controls.Gameplay.moveUp.triggered)
            return 1;
        else if (controls.Gameplay.moveDown.triggered)
            return -1;
        return 0;
    }
}
