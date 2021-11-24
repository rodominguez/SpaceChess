using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && other.GetComponent<ShipMovement>().GetIsShoot())
        {
            other.GetComponent<DIe>().Die();
        }
    }
}
