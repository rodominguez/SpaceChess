using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> targets = new List<GameObject>();
    [SerializeField] private int maxBounces;

    private bool isFinished;
    private Text maxBouncesText;

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
        return !isCanFire && currentBounces < 0 && !isFinished;
    }

    public void SubstractBounce()
    {
        currentBounces--;
        maxBouncesText.text = "Max Bounces: " + currentBounces;
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

    public void SetBouncesText(Text maxBouncesText)
    {
        this.maxBouncesText = maxBouncesText;
        maxBouncesText.text = "Max Bounces: " + maxBounces;
    }

    public GameObject GetBullet()
    {
        return bullet;
    }
}
