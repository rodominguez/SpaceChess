using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    private float tagTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet") && tagTime <= Time.time)
        {
            tagTime = other.GetComponent<ProjectileMoveScript>().Bounce(gameObject);
        }
    }
}
