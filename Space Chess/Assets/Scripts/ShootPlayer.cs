using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject mouse;
    [SerializeField] private GameObject directionIndicator;

    private ShipMovement shipMovement;
    private bool isPlayerShot;
    private Vector3 shotPosition;

    void Start()
    {
        shipMovement = GetComponent<ShipMovement>();
    }

    private void Update()
    {
        if (InputManager.Instance.GetShoot() && !isPlayerShot)
        {
            mouse.SetActive(false);
            directionIndicator.SetActive(false);
            shipMovement.SetIsShoot(true);
            shotPosition = transform.position;
            isPlayerShot = true;
        }
    }

    public void ResetPlayer()
    {
        FixPosition();
        mouse.SetActive(true);
        shipMovement.SetIsShoot(false);
        isPlayerShot = false;
        directionIndicator.SetActive(true);
    }

    public void ResetPlayer(bool isDied)
    {
        if (isDied)
            transform.position = shotPosition;
        FixPosition();
        mouse.SetActive(true);
        shipMovement.SetIsShoot(false);
        isPlayerShot = false;
        directionIndicator.SetActive(true);
    }

    private void FixPosition()
    {
        Vector3 finalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        float x = (int)finalPosition.x;
        x += finalPosition.x < 0 ? -0.5f : 0.5f;

        float y = (int)finalPosition.y;
        y += finalPosition.y < 0 ? -0.5f : 0.5f;

        finalPosition.x = x;
        finalPosition.y = y;

        transform.position = finalPosition;
    }
}
