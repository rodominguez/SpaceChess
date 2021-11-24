using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIe : MonoBehaviour
{
    [SerializeField] private float shrinkSpeed;
    [SerializeField] private Vector3 initialScale;

    private bool isDying;
    private bool isDead;
    private float timeToDie;

    private void Update()
    {
        if (isDying && Time.time < timeToDie)
        {
            Shrink();
        }
        else if (isDying && Time.time >= timeToDie)
        {
            isDead = true;
            isDying = false;
        }
    }

    public void Revive()
    {
        isDead = false;
        transform.localScale = initialScale;
    }

    public void Die()
    {
        GetComponent<ShipMovement>().SetIsShoot(false);
        isDying = true;
        timeToDie = Time.time + 2;
    }

    void Shrink()
    {
        transform.localScale += new Vector3(-1f, -1f, -1f) * Time.deltaTime * shrinkSpeed;
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
