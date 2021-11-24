using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> targets = new List<GameObject>();
    [SerializeField] private int maxBounces;
    [SerializeField] private int maxVerticalWalls;
    [SerializeField] private int maxHorizontalWalls;
    [SerializeField] private bool isBlack;
    [SerializeField] private long pointsPerTarget;
    [SerializeField] private long pointsPerBounce;
    [SerializeField] private long pointsPerWall;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private bool isUseStartPosition;
    [TextArea]
    [SerializeField] private string tips;

    private bool isFinished;
    private Text maxBouncesText;
    private Text verticalWallsText;
    private Text horizontalWallsText;

    private bool isDying;
    private int currentBounces;
    private int currentVerticalWalls;
    private int currentHorizontalWalls;

    private bool isCanFire;

    private void Start()
    {
        isCanFire = true;
        currentBounces = maxBounces;
        currentHorizontalWalls = maxHorizontalWalls;
        currentVerticalWalls = maxVerticalWalls;
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
        return currentBounces < 0 && !isFinished;
    }

    public void SubstractBounce()
    {
        currentBounces--;
        maxBouncesText.text = "Max Bounces: " + currentBounces;
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

    public void SetVerticalWallsText(Text verticalWallsText)
    {
        this.verticalWallsText = verticalWallsText;
        this.verticalWallsText.text = "" + maxVerticalWalls;
    }

    public void SetHorizontalWallsText(Text horizontalWallsText)
    {
        this.horizontalWallsText = horizontalWallsText;
        this.horizontalWallsText.text = "" + maxHorizontalWalls;
    }

    public bool GetIsBlack()
    {
        return isBlack;
    }

    public long AwardPoints()
    {
        long points = targets.Count * pointsPerTarget + currentBounces * pointsPerBounce + currentVerticalWalls * pointsPerWall + currentHorizontalWalls * pointsPerWall;
        return points;
    }

    public int GetCurrentHorizontalWalls()
    {
        return currentHorizontalWalls;
    }

    public int GetCurrentVerticalWalls()
    {
        return currentVerticalWalls;
    }

    public void SubstractVerticalWalls()
    {
        currentVerticalWalls--;
        this.verticalWallsText.text = "" + currentVerticalWalls;
    }

    public void SubstractHorizontalWalls()
    {
        currentHorizontalWalls--;
        this.horizontalWallsText.text = "" + currentHorizontalWalls;
    }

    public bool IsCanDrag()
    {
        return isCanFire;
    }

    public void SetPlayerPosition(GameObject player)
    {
        if (isUseStartPosition)
            player.transform.position = startPosition;
    }

    public string GetTips()
    {
        return tips;
    }
}
