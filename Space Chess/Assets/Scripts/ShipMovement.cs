using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private bool isBlack;
    private bool isDragged;

    private void Update()
    {
        //Move();
        CorrectBoundaries();
        if (transform.position.z != 0f)
            CorrectColor();
    }

    private void Move()
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

    private void CorrectBoundaries()
    {
        Vector3 finalPosition = transform.position;

        finalPosition.x = finalPosition.x < -3.5f ? -3.5f : finalPosition.x > 3.5f ? 3.5f : finalPosition.x;
        finalPosition.y = finalPosition.y > -0.5f ? -0.5f : finalPosition.y < -7.5f ? -7.5f : finalPosition.y;

        transform.position = finalPosition;
    }

    private void CorrectColor()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        x += 4;
        y += 8;


        if (IsWhiteSquare(x, y) && isBlack)
            CorrectSquare();
        else if (!IsWhiteSquare(x,y) && !isBlack)
            CorrectSquare();
    }

    private bool IsWhiteSquare(float x, float y)
    {
        if ((int)x % 2 == 1 && (int)y % 2 == 0)
            return true;

        if ((int)x % 2 == 0 && (int)y % 2 == 1)
            return true;

        return false;
    }

    private void CorrectSquare()
    {
        if (transform.position.x + 4 < 4)
            transform.position += new Vector3(1f, 0f, 0f);
        else
            transform.position += new Vector3(-1f, 0f, 0f);
    }

    public void SetIsBlack(bool isBlack)
    {
        this.isBlack = isBlack;
    }

    public void SetIsDragged(bool isDragged)
    {
        this.isDragged = isDragged;
    }
}
