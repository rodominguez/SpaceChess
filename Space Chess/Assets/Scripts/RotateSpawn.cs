using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawn : MonoBehaviour
{

    [SerializeField] private Transform spawn;

    bool isDown;
    bool isLeft;

    private void Update()
    {
        if (InputManager.Instance.GetSwitchAngleHorizontal() == 1)
        {
            if (!isDown)
                spawn.eulerAngles = new Vector3(0, 0, -45);
            else
                spawn.eulerAngles = new Vector3(0, 0, -135);
            isLeft = false;
        }
        else if (InputManager.Instance.GetSwitchAngleHorizontal() == -1)
        {
            if (!isDown)
                spawn.eulerAngles = new Vector3(0, 0, 45);
            else
                spawn.eulerAngles = new Vector3(0, 0, 135);
            isLeft = true;
        }

        if (InputManager.Instance.GetSwitchAngleVertical() == 1)
        {
            if (!isLeft)
                spawn.eulerAngles = new Vector3(0, 0, -45);
            else
                spawn.eulerAngles = new Vector3(0, 0, 45);
            isDown = false;
        }
        else if (InputManager.Instance.GetSwitchAngleVertical() == -1)
        {
            if (!isLeft)
                spawn.eulerAngles = new Vector3(0, 0, -135);
            else
                spawn.eulerAngles = new Vector3(0, 0, 135);
            isDown = true;
        }  
    }
}
