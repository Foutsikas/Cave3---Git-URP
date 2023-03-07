using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject answerButtonPrefab; // reference to the button prefab to generate answer buttons
    public Transform answerButtonParent; // reference to the parent transform to attach answer buttons to
    public int currentQuestion;

    public GameObject GameOverPanel;

    public TMP_Text ScoreTxt;

    int TotalQuestions = 0;
    public int Score;
    public GameObject QuestionPanel;
    public GameObject AnswerPanel;

    public TMP_Text QuestionTxt;

    private void Start()
    {
        TotalQuestions = QnA.Count;
        GameOverPanel.SetActive(false);
        generateQuestion();
    }

    void GameOver()
    {
        QuestionPanel.SetActive(false);
        AnswerPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        ScoreTxt.text = Score + "/" + TotalQuestions;
    }

    public void correct()
    {
        Score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        // Destroy any existing answer buttons
        foreach (Transform child in answerButtonParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate answer buttons
        for (int i = 0; i < QnA[currentQuestion].AnswerKeys.Length; i++)
        {
            GameObject answerButton = Instantiate(answerButtonPrefab, answerButtonParent);
            answerButton.transform.GetChild(0).GetComponent<LocalizeStringEvent>().StringReference.SetReference("QuizTable", QnA[currentQuestion].AnswerKeys[i]); // set the reference using the answer key
            if (i == QnA[currentQuestion].CorrectAnswer)
            {
                answerButton.GetComponent<Button>().onClick.AddListener(correct);
            }
            else
            {
                answerButton.GetComponent<Button>().onClick.AddListener(wrong);
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            // set the reference using the question key
            QuestionTxt.GetComponent<LocalizeStringEvent>().StringReference.SetReference("QuizTable", QnA[currentQuestion].QuestionKey);

            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
