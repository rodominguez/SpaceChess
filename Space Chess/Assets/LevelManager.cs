using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private GameObject currentLevel;
    private int currentLevelIndex = 0;

    private float timeToSpawn = 0f;
    private bool isSpawning;

    private void Start()
    {
        SpawnLevel();
    }

    private void Update()
    {
        ChangeLevel();    
    }

    private void ChangeLevel()
    {
        if (currentLevel != null && currentLevel.GetComponent<Level>().IsFinished() && !isSpawning)
        {
            isSpawning = true;
            timeToSpawn = Time.time + 4f;
        }

        if (isSpawning && Time.time >= timeToSpawn)
        {
            currentLevelIndex++;
            if (currentLevelIndex < levels.Count)
                SpawnLevel();
            isSpawning = false;
        }
    }

    private void SpawnLevel()
    {
        GameObject level = Instantiate(levels[currentLevelIndex], Vector3.zero, Quaternion.identity);
        level.transform.parent = transform;
        currentLevel = level;
    }
}
