using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private void Update()
    {
        if (InputManager.Instance.GetShipMovementHorizontal() == 1)
            transform.position += new Vector3(1, 0f, 0f);
        else if (InputManager.Instance.GetShipMovementHorizontal() == -1)
            transform.position += new Vector3(-1, 0f, 0f);

        if (InputManager.Instance.GetShipMovementVertical() == 1)
            transform.position += new Vector3(0, 1f, 0f);
        else if (InputManager.Instance.GetShipMovementVertical() == -1)
            transform.position += new Vector3(0, -1f, 0f);
    }
}
