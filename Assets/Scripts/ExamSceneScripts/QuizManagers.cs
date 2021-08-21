using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManagers : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject  RoundOver;

    public GameObject Quizpanel;
    

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions=0;
    public int score;

    private void Start()
    {
        RoundOver.SetActive(false);
        totalQuestions=QnA.Count;
        generateQuestion();

    }
    public void goBack()
    {
        Debug.Log("Score"+ score);
        if(score>=2)
        { 
            SceneManager.LoadScene("GraduationScene");
            
        }
        else
        {
            SceneManager.LoadScene("NotGraduationScene");
        }

        

    }
    public void GameOver()
    {
        RoundOver.SetActive(true);
        Quizpanel.SetActive(false);
        ScoreTxt.text= "Score: "+ score*25;

    }

    public void correct()
    {
        score+=1;
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
        for(int i=0;i<options.Length;i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect=false;
            options[i].transform.GetChild(0).GetComponent<Text>().text=QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect=true;
            }
        }

    }

    void generateQuestion()
    {
        if(QnA.Count>0)
        {
            currentQuestion=Random.Range(0, QnA.Count);
            QuestionTxt.text=QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
        
        
    }
}
