using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    [SerializeField] private Text pointsUI;

    private long points;

    private long displayPoints;

    private string format = "00000000";

    private ValidMoves validMoves;

    private void Start()
    {
        validMoves = GetComponent<ValidMoves>();
    }

    private void Update()
    {
        if (displayPoints <= points)
        {
            pointsUI.text = "Points: " + displayPoints.ToString(format);

            if (displayPoints + 10000 < points)
                displayPoints += 2000;
            else if (displayPoints + 1000 < points)
                displayPoints += 200;
            else if (displayPoints + 20 < points)
                displayPoints += 20;
            else if (displayPoints + 1 <= points)
                displayPoints += 1;
        }
    }

    public void Reset()
    {
        points = 0;
    }

    public void AddPoints(long points)
    {
        if (validMoves != null)
        {
            points = validMoves.GetInvalidMoves() > 0 ? 0 : points;
            validMoves.ResetMoves();
        }

        this.points += points;
    }

    public long CalculateLevelPoints(long points)
    {
        if (validMoves != null)
        {
            points = validMoves.GetInvalidMoves() > 0 ? 0 : points;
        }

        

        return points;
    }

    public long GetPoints()
    {
        return points;
    }

    public long GetFinalPoints(int lives)
    {
        return points + (lives * 10000);
    }
}
