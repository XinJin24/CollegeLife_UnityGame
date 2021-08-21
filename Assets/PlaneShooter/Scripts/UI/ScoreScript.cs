using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] static int score =0;
    [SerializeField] static Text ScoreTxt;
    //    [SerializeField] Text scoreTxt;
    void Start()
    {
        ScoreTxt=GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text="Scores "+score;
    }
    public static void IncrementScore(int amount)
    {
        if(amount<0)
        {
            Debug.Log("Invalid, score can not be less than zero");
        }
        else
        {
            score=score+amount;
        }
    }
    public static void IncrementScore()
    {
        IncrementScore(1);
    }
    public static void DisplayScores()
    {
        ScoreTxt.text= "Scores: "+ score; 
    }

    public static int getScore()
    {
        return score;
    }
    public static void SetScore(int score1)
    {
        score=score1;
    }
    /*
    public void DisplayScores()
    {
        scoreTxt.text="Scores: "+ scoreTxt;
    }
    */
}
