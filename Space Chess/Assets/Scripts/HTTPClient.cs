using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPClient : Singleton<HTTPClient>
{
    [SerializeField] private string addPlayerURL;
    [SerializeField] private string addGameURL;
    [SerializeField] private string updateGameURL;
    [SerializeField] private string addLevelURL;
    [SerializeField] private string addQuestionsURL;
    [SerializeField] private bool isDebugMode;

    private static int idPlayer;
    private static int idGame;

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        if (idPlayer == 0)
            AddPlayerRequest();
    }

    public void AddPlayerRequest()
    {
        if (!isDebugMode)
            StartCoroutine(AddPlayer());
    }
    IEnumerator AddPlayer()
    {

        string date = System.DateTime.Now.ToString().Replace("/", "-").Replace("PM", "");
        string request = addPlayerURL + "/" + date;
        UnityWebRequest www = UnityWebRequest.Get(request);
        yield return www.SendWebRequest();

        if (www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            idPlayer = int.Parse(www.downloadHandler.text);
            Debug.Log("Player created. ID = " + idPlayer);
        }
    }

    public void AddGameRequest(int gameType, long points)
    {
        if (!isDebugMode)
            StartCoroutine(AddGameScore(gameType, points));
    }

    IEnumerator AddGameScore(int gameType, long points)
    {
        yield return new WaitUntil(() => idPlayer != 0);
        string date = System.DateTime.Now.ToString().Replace("/", "-").Replace("PM", "");
        string request = addGameURL + "/" + idPlayer + "/" + gameType + "/" + points + "/" + date;
        UnityWebRequest www = UnityWebRequest.Get(request);
        yield return www.SendWebRequest();

        if (www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            idGame = int.Parse(www.downloadHandler.text);
            Debug.Log("Game created. ID = " + idGame);
        }
    }

    public void UpdateGameScoreRequest(long points)
    {
        if (!isDebugMode)
            StartCoroutine(UpdateGameScore(points));
    }

    IEnumerator UpdateGameScore(long points)
    {
        string request = updateGameURL + "/" + idGame + "/" + points;
        UnityWebRequest www = UnityWebRequest.Get(request);
        yield return www.SendWebRequest();

        if (www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Game updated.");
        }
    }

    public void AddLevelRequest(long points, long time, int index)
    {
        if (!isDebugMode)
            StartCoroutine(AddLevel(points, time, index));
    }

    IEnumerator AddLevel(long points, long time, int index)
    {
        string request = addLevelURL + "/" + idGame + "/" + points + "/" + time + "/" + index;
        UnityWebRequest www = UnityWebRequest.Get(request);
        yield return www.SendWebRequest();

        if (www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Level information added.");
        }
    }

    public void AddQuestionsRequest(int[] answers)
    {
        if (!isDebugMode)
            StartCoroutine(AddQuestions(answers));
    }

    IEnumerator AddQuestions(int[] answers)
    {
        string request = addQuestionsURL + "/" + idPlayer + "/" + answers[0] + "/" + answers[1] + "/" + answers[2] + "/" + answers[3];
        UnityWebRequest www = UnityWebRequest.Get(request);
        yield return www.SendWebRequest();

        if (www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Question answers added.");
        }
    }
}
