using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenEntPanel : MonoBehaviour
{
    public GameObject entertainmentPanel;
    [SerializeField] Text selectedEntItems;
    [SerializeField] Dropdown entertainmentDropdown;
    //[SerializeField] Button closeEntButton;
    [SerializeField] Button learningButton;
    [SerializeField] Button entertainmentButton;

    [SerializeField]
    List<string> items = new List<string>() {"Please select one", "Play Game!", "Watching TV", "Hang Out with friends", "Exercising outdoor" };

    [SerializeField] int game = 0;
    [SerializeField] int tv = 0;
    [SerializeField] int friends = 0;
    [SerializeField] int exercise = 0;

    [SerializeField] float waitSec = 0.5f;

    /*
    [SerializeField] Text gameTxt;
    [SerializeField] Text tvTxt;
    [SerializeField] Text friendsTxt;
    [SerializeField] Text exerciseTxt;
    */


    public void ShowEntPanel()
    {
        if (entertainmentPanel != null)
        {
            entertainmentPanel.SetActive(true);

            PopulateEntList();
        }
    }

    public void PopulateEntList()
    {
        entertainmentDropdown.ClearOptions();
        entertainmentDropdown.AddOptions(items);
    }

    public void EntDropdown_IndexChanged(int index)
    {
        if (index == 0)
        {
            selectedEntItems.text = "You must select at least one subject";
            selectedEntItems.color = Color.white;
        }
        else
        {
            selectedEntItems.text = "Your choice :\n" + items[index];
            selectedEntItems.color = Color.black;
            entertainmentDropdown.interactable = !entertainmentDropdown.interactable;

            if (index == 1)
            {
                IncrementGame();
                //DisplayGame();
            }
            else if (index == 2)
            {
                IncrementTV();
                //DisplayTV();
            }
            else if (index == 3)
            {
                IncrementFriends();
                //DisplayFriends();
            }
            else
            {
                IncrementExercise();
                //DisplayExercise();
            }                
        }
        StartCoroutine(HideEntPanel());
        //yield return StartCoroutine(HidePanel());
    }

    IEnumerator HideEntPanel()
    {
        yield return new WaitForSeconds(waitSec);
        if (entertainmentPanel.activeInHierarchy)
        {
            if (!entertainmentDropdown.IsInteractable())
            {
                entertainmentDropdown.interactable = !entertainmentDropdown.interactable;
            }
            selectedEntItems.text = "Please select one !";

            entertainmentPanel.SetActive(false);
        }
        InteractableToTrue();
    }

    public void InteractableToTrue()
    {
        if (learningButton.interactable == false && entertainmentButton.interactable == false)
        {
            learningButton.interactable = true;
            entertainmentButton.interactable = true;
        }
    }

    public void IncrementGame(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: game count may not be less than zero.");
        else
            game += amount;
    }

    public void IncrementGame()
    {
        IncrementGame(1);
        //DisplayGame();
    }

    public void IncrementTV(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: TV count may not be less than zero.");
        else
            tv += amount;
    }

    public void IncrementTV()
    {
        IncrementTV(1);
        //DisplayTV();
    }

    public void IncrementFriends(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: Friends count may not be less than zero.");
        else
            friends += amount;
    }

    public void IncrementFriends()
    {
        IncrementFriends(1);
        //DisplayFriends();
    }

    public void IncrementExercise(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: game count may not be less than zero.");
        else
            exercise += amount;
    }

    public void IncrementExercise()
    {
        IncrementExercise(1);
        //DisplayExercise();
    }

    /*
     public void DisplayGame()
    {
        gameTxt.text = "Game : " + game;
    }

    public void DisplayTV()
    {
        tvTxt.text = " Watching TV : " + tv;
    }

    public void DisplayFriends()
    {
        friendsTxt.text = "Hanging with Friends : " + friends;
    }

    public void DisplayExercise()
    {
        exerciseTxt.text = "CS Theory : " + exercise;
    }
    */
}

