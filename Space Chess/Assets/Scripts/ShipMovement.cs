using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private bool isShoot;
    [SerializeField] private bool isNotBounce;
    [SerializeField] private bool isDragAndDropMode;

    private bool isBlack;
    private bool isDragged;

    private void Update()
    {
        Move();
        //CorrectBoundaries();
        if (transform.position.z != 0f && !isShoot)
            CorrectColor();

    }

    private void Move()
    {
        if (isShoot)
        {
            transform.position += (transform.forward) * (speed) * Time.deltaTime;
            if (!isNotBounce)
                Bounce();
        }
    }

    void Bounce()
    {
        if (transform.localPosition.x <= -3.5)
        {
            Vector3 direction = new Vector3(transform.forward.x * -1, transform.forward.y, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(-3.5f, transform.localPosition.y, transform.localPosition.z);
            levelManager.GetCurrentLevel().SubstractBounce();
        }
        else if (transform.localPosition.x >= 3.5)
        {
            Vector3 direction = new Vector3(transform.forward.x * -1, transform.forward.y, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(3.5f, transform.localPosition.y, transform.localPosition.z);
            levelManager.GetCurrentLevel().SubstractBounce();
        }
        else if (transform.localPosition.y >= -0.5)
        {
            Vector3 direction = new Vector3(transform.forward.x, transform.forward.y * -1, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f, transform.localPosition.z);
            levelManager.GetCurrentLevel().SubstractBounce();
        }
        else if (transform.localPosition.y <= -7.5)
        {
            Vector3 direction = new Vector3(transform.forward.x, transform.forward.y * -1, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(transform.localPosition.x, -7.5f, transform.localPosition.z);
            levelManager.GetCurrentLevel().SubstractBounce();
        }
    }

    public float Bounce(GameObject wall, Vector3 directionBounce)
    {
        Vector3 direction = new Vector3(transform.forward.x * directionBounce.x, transform.forward.y * directionBounce.y, transform.forward.z * directionBounce.z);

        transform.LookAt(transform.position + direction * 10);
        transform.position = wall.transform.position;

        levelManager.GetCurrentLevel().SubstractBounce();

        return Time.time + 0.3f;
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
        transform.position = new Vector3(transform.position.x, transform.position.y, -2.1f);
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

    public void SetIsShoot(bool isShoot)
    {
        this.isShoot = isShoot;
    }

    public bool GetIsShoot()
    {
        return isShoot;
    }

    public bool GetIsDragAndDropMode()
    {
        return isDragAndDropMode;
    }
}
