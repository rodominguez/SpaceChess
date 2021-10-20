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
            Debug.Log("Bounce");
            Vector3 direction = new Vector3(other.transform.forward.x * -1, other.transform.forward.y, other.transform.forward.z);

            other.transform.LookAt(other.transform.position + direction * 10);
            other.transform.position = transform.position;

            tagTime = Time.time + 1f;
        }
    }
}
