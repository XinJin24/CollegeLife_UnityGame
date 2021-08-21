using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] displayWhenPlay;
    [SerializeField] GameObject[] displayWhenPaused;
    void Start()
    {
        displayWhenPlay= GameObject.FindGameObjectsWithTag("showInPlayMode");
        displayWhenPaused= GameObject.FindGameObjectsWithTag("showInPauseMode");

        foreach(GameObject g in displayWhenPaused)
        {
            g.SetActive(true);
        }

        foreach(GameObject g in displayWhenPlay)
        {
            g.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        Time.timeScale=0.0f;

        foreach(GameObject g in displayWhenPaused)
        {
            g.SetActive(true);
        }

        foreach(GameObject g in displayWhenPlay)
        {
            g.SetActive(true);
        }

        
    }
    public void ResumeGame()
    {
        Time.timeScale=1.0f;

        foreach(GameObject g in displayWhenPaused)
        {
            g.SetActive(false);
        }

        foreach(GameObject g in displayWhenPlay)
        {
            g.SetActive(true);
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("Game");
    }

    

}
