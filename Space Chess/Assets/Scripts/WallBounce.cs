using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    [SerializeField] private Vector3 directionBounce;

    private float tagTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && other.GetComponent<ShipMovement>().GetIsShoot() && tagTime <= Time.time)
        {
            tagTime = other.GetComponent<ShipMovement>().Bounce(gameObject, directionBounce);
        }
    }
}
