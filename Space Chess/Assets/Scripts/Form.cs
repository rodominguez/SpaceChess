using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Form : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private List<string> questions = new List<string>();
    [SerializeField] private GameObject gameResults;
    [SerializeField] private PointSystem pointSystem;

    private int questionIndex;
    private int[] questionAnswers;

    private void Start()
    {
        questionIndex = 0;
        questionAnswers = new int[questions.Count];
        ShowQuestion();
    }

    public void NextQuestion(bool isYes)
    {
        questionAnswers[questionIndex] = isYes ? 1 : 0;
        questionIndex++;
        if (questionIndex == questions.Count)
            GoToGameResults();
        else
            ShowQuestion();
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    private void ShowQuestion()
    {
        text.text = questions[questionIndex];
    }

    private void GoToGameResults()
    {
        gameResults.SetActive(true);
        gameObject.SetActive(false);
        gameResults.GetComponent<GameResults>().SetPoints(pointSystem.GetFinalPoints(0));
        Debug.Log(questionAnswers[0] + " " + questionAnswers[1] + " " + questionAnswers[2] + " " + questionAnswers[3] + " ");
        HTTPClient.Instance.AddQuestionsRequest(questionAnswers);
    }
}
