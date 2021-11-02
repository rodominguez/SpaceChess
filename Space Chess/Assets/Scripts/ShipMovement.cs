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

        Vector3 finalPosition = transform.position;

        finalPosition.x = finalPosition.x < -3.5f ? -3.5f : finalPosition.x > 3.5f ? 3.5f : finalPosition.x;
        finalPosition.y = finalPosition.y > -0.5f ? -0.5f : finalPosition.y < -7.5f ? -7.5f : finalPosition.y;

        transform.position = finalPosition;
    }
}
