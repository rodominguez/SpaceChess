using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : Singleton<InputManager>
{
    PlayerControls controls;

    private float timeToFire = 0f;


    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
        //TouchSimulation.Enable();
        //EnhancedTouchSupport.Enable();
    }

    public float GetSwitchAngleHorizontal()
    {
        return controls.Gameplay.switchAngleHorizontal.ReadValue<float>();
    }

    public float GetSwitchAngleVertical()
    {
        return controls.Gameplay.switchAngleVertical.ReadValue<float>();
    }

    public bool IsPressed()
    {
        //return Touchscreen.current.press.isPressed;
        return Mouse.current.leftButton.isPressed;
    }

    public Vector3 GetMousePosition()
    {
        //return new Vector3(Touchscreen.current.position.x.ReadValue(), Touchscreen.current.position.y.ReadValue(), 0f);
        return new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 0f);
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

    public bool GetShoot()
    {
        if (controls.Gameplay.shoot.ReadValue<float>() > 0.1)
        {
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
