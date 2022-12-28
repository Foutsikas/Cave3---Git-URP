using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public QuizManager quizManager;
    public bool isCorrect;

    public void Answers()
    {
        if (isCorrect)
        {
            Debug.Log("Correct");
            quizManager.correct();
        }else{
            Debug.Log("Wrong");
            quizManager.wrong();
        }
    }
}
