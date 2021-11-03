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

    private void Update()
    {
        if (displayPoints <= points)
        {
            pointsUI.text = "Points: " + displayPoints.ToString(format);

            if (displayPoints + 10 < points)
                displayPoints += 10;
            else
                displayPoints += 1;
        }
    }

    public void Reset()
    {
        points = 0;
    }

    public void AddPoints(long points)
    {
        this.points += points;
    }
}
