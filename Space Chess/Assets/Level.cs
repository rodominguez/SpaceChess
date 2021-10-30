using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> targets = new List<GameObject>();
    [SerializeField] private int maxBounces;

    private bool isFinished;

    private bool isDying;
    private int currentBounces;

    private bool isCanFire;
    private GameObject bullet;

    private void Start()
    {
        isCanFire = true;
        currentBounces = maxBounces;
    }

    private void Update()
    {
        CheckIfFinished();
    }

    void CheckIfFinished()
    {
        bool isFinished = true;

        foreach (GameObject o in targets)
        {
            if (!o.GetComponent<Destroy>().IsDead())
                isFinished = false;
        }

        if (isFinished)
            this.isFinished = true;

        if (this.isFinished && !isDying)
        {
            StartCoroutine(waiter());
            isDying = true;
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }

    public bool IsFinished()
    {
        return isFinished;
    }

    public bool IsNeedToRestart()
    {
        return !isCanFire && bullet == null && !isFinished;
    }

    public void SubstractBounce()
    {
        currentBounces--;
    }

    public void SetBullet(GameObject bullet)
    {
        this.bullet = bullet;
        isCanFire = false;
    }

    public bool IsCanFire()
    {
        return isCanFire;
    }
}
