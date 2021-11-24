using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    [SerializeField] private Text maxBounces;
    [SerializeField] private GameObject player;
    [SerializeField] private Text verticalWalls;
    [SerializeField] private Text horizontalWalls;
    [SerializeField] private GameObject draggableWallsParent;
    [SerializeField] private List<GameObject> lives = new List<GameObject>();
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Text tips;
    [SerializeField] private int gameType;
    [SerializeField] private GameObject mainPanel;

    private GameObject currentLevel;
    private int currentLevelIndex = 0;

    private float timeToSpawn = 0f;
    private bool isSpawning;
    private int currentLives;
    private float levelTime;

    private void Start()
    {
        HTTPClient.Instance.AddGameRequest(gameType, 0);
        SpawnLevel();
        currentLives = lives.Count;
    }

    private void Update()
    {
        ChangeLevel();
        RestartLevel();
    }

    private void RestartLevel()
    {
        if (currentLevel == null) return;
        if (currentLevel.GetComponent<Level>().IsNeedToRestart() || player.GetComponent<DIe>().GetIsDead())
        {
            HTTPClient.Instance.AddLevelRequest(0, (long)(Time.time - levelTime), currentLevelIndex);
            LoseLife();
            if (!player.GetComponent<ShipMovement>().GetIsDragAndDropMode())
                player.GetComponent<ShootPlayer>().ResetPlayer(player.GetComponent<DIe>().GetIsDead());
            if (player.GetComponent<ValidMoves>() != null)
            {
                player.transform.position = player.GetComponent<DragAndDrop>().GetInitialPosition();
                player.GetComponent<ShipMovement>().SetIsShoot(true);
            }
            player.GetComponent<DIe>().Revive();
            Destroy(currentLevel);
            DeleteDraggableWalls();
            currentLevel.GetComponent<Level>().SetPlayerPosition(player);
            SpawnLevel();
        }
    }

    private void ChangeLevel()
    {
        if (currentLevel != null && currentLevel.GetComponent<Level>().IsFinished() && !isSpawning)
        {
            if (!player.GetComponent<ShipMovement>().GetIsDragAndDropMode())
                player.GetComponent<ShootPlayer>().ResetPlayer();
            HTTPClient.Instance.AddLevelRequest(player.GetComponent<PointSystem>().CalculateLevelPoints(currentLevel.GetComponent<Level>().AwardPoints()),
                (long)(Time.time - levelTime), currentLevelIndex);
            player.GetComponent<PointSystem>().AddPoints(currentLevel.GetComponent<Level>().AwardPoints());
            DeleteDraggableWalls();
            isSpawning = true;
            timeToSpawn = Time.time + 4f;
        }

        if (isSpawning && Time.time >= timeToSpawn)
        {
            currentLevelIndex++;
            if (currentLevelIndex < levels.Count)
            {
                SpawnLevel();
                currentLevel.GetComponent<Level>().SetPlayerPosition(player);
            }
            else
                ShowEndScreen();
            isSpawning = false;
        }
    }

    private void LoseLife()
    {
        currentLives--;
        lives[currentLives].SetActive(false);
        if (currentLives == 0)
            ShowEndScreen();
    }

    private void ShowEndScreen()
    {
        int livesToSend = gameType == 1 ? currentLives : 0;
        HTTPClient.Instance.UpdateGameScoreRequest(player.GetComponent<PointSystem>().GetFinalPoints(livesToSend));
        endScreen.SetActive(true);
        if (endScreen.GetComponent<GameResults>() != null)
            endScreen.GetComponent<GameResults>().SetPoints(player.GetComponent<PointSystem>().GetFinalPoints(livesToSend));
        player.SetActive(false);
        mainPanel.SetActive(false);
    }

    private void SpawnLevel()
    {
        GameObject level = Instantiate(levels[currentLevelIndex], Vector3.zero, Quaternion.identity);
        level.transform.parent = transform;
        currentLevel = level;
        level.GetComponent<Level>().SetBouncesText(maxBounces);
        level.GetComponent<Level>().SetVerticalWallsText(verticalWalls);
        level.GetComponent<Level>().SetHorizontalWallsText(horizontalWalls);
        player.GetComponent<Appearance>().SetAppearance(level.GetComponent<Level>().GetIsBlack());
        player.GetComponent<ShipMovement>().SetIsBlack(level.GetComponent<Level>().GetIsBlack());
        tips.text = "Tips: \n" + level.GetComponent<Level>().GetTips();
        levelTime = Time.time;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Bishop", LoadSceneMode.Single);
        /*endScreen.SetActive(false);
        player.SetActive(true);
        currentLives = 3;

        foreach (GameObject o in lives)
            o.SetActive(true);

        if (currentLevel != null)
        {
            player.GetComponent<ShootPlayer>().ResetPlayer();
            player.GetComponent<PointSystem>().Reset();
            DeleteDraggableWalls();
            isSpawning = true;
            timeToSpawn = Time.time + 4f;
        }

        currentLevelIndex = 0;

        SpawnLevel();*/
    }

    public Level GetCurrentLevel()
    {
        if (currentLevel == null) return null;
        return currentLevel.GetComponent<Level>();
    }

    private void DeleteDraggableWalls()
    {
        for (int i = 0; i < draggableWallsParent.transform.childCount; i++)
        {
            Destroy(draggableWallsParent.transform.GetChild(i).gameObject);
        }
    }
}
