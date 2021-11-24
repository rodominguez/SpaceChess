using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResults : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Text text;

    private long points;
    private long displayPoints;

    private string format = "00000000";

    private void Update()
    {
        if (displayPoints + 10000 < points)
            displayPoints += 2000;
        else if (displayPoints + 1000 < points)
            displayPoints += 200;
        else if (displayPoints + 20 < points)
            displayPoints += 20;
        else if (displayPoints + 1 <= points)
            displayPoints += 1;

        text.text = "" + displayPoints;
    }

    public void Restart()
    {
        levelManager.RestartGame();
    }

    public void SetPoints(long points)
    {
        this.displayPoints = 0;
        this.points = points;
    }

    public void FinalChallenge()
    {
        SceneManager.LoadScene("BishopTest", LoadSceneMode.Single);
    }

    public void Practice()
    {
        SceneManager.LoadScene("Bishop", LoadSceneMode.Single);
    }
}
