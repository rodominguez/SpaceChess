using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> targets = new List<GameObject>();

    private bool isFinished;

    private bool isDying;

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
}
