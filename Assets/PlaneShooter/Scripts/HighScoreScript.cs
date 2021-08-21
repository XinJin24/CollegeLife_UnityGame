using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class HighScoreScript : MonoBehaviour
{

    public  Text first;

    int score;

    void Start()
    {
        score=ScoreScript.getScore();
        Debug.Log(score);
        first.text =""+score;
    }

    public void Goback()
        {
            SceneManager.LoadScene("Game");
        }


}
