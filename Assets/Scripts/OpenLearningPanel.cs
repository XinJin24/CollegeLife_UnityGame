using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLearningPanel: MonoBehaviour
{
    public GameObject subjectPanel;
    [SerializeField] Text selectedItems;
    [SerializeField] Dropdown subjectDropdown;
    //[SerializeField] Button closeButton;

    [SerializeField] Button learningButton;
    [SerializeField] Button entertainmentButton;

    [SerializeField]
    List<string> items = new List<string>() { "Please select one", "Study for English Class", "Study Math", "Study CS Coding", "Study CS Theory" };

    [SerializeField] int english = 0;
    [SerializeField] int math = 0;
    [SerializeField] int csCoding = 0;
    [SerializeField] int csTheory = 0;

    [SerializeField] float waitTime = 0.5f;
    /*
    [SerializeField] Text englishTxt;
    [SerializeField] Text mathTxt;
    [SerializeField] Text csCodingTxt;
    [SerializeField] Text csTheoryTxt;
    */

    public void ShowPanel()
    {
        if (subjectPanel != null)
        {
            subjectPanel.SetActive(true);

            PopulateList();
        }
    }

    public void PopulateList()
    {
        subjectDropdown.ClearOptions();
        subjectDropdown.AddOptions(items);
    }

    public void Dropdown_IndexChanged(int index)
    {
        if (index == 0)
        {
            selectedItems.text = "You must select at least one subject";
            selectedItems.color = Color.white;
        }
        else
        {
            selectedItems.text = "Your choose to :\n" + items[index];
            selectedItems.color = Color.black;
            subjectDropdown.interactable = !subjectDropdown.interactable;

            if (index == 1)
            {
                IncrementEnglish();
                //DisplayEnglish();
            }
            else if (index == 2)
            {
                IncrementMath();
                //DisplayMath();
            }
            else if (index == 3)
            {
                IncrementCsCoding();
                //DisplayCsCoding();
            }
            else
            {
                IncrementCsTheory();
                //DisplayCsTheory();
            }
        }

        //StartCoroutine(InvokeInteractable());
        //yield return StartCoroutine(HidePanel());
        StartCoroutine(HidePanel());
    }

    /*
     * IEnumerator InvokeInteractable()
    {
        yield return new WaitForSeconds(waitTime);
        yield return StartCoroutine(HidePanel());
    }
    */

    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(waitTime);

        if (subjectPanel.activeInHierarchy)
        {
            if (!subjectDropdown.IsInteractable())
            {
                subjectDropdown.interactable = !subjectDropdown.interactable;
            }
            selectedItems.text = "Please select one subject!";

            subjectPanel.SetActive(false);
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

    public void IncrementEnglish(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: English count may not be less than zero.");
        else
            english += amount;
    }

    public void IncrementEnglish()
    {
        IncrementEnglish(1);
        //DisplayEnglish();
    }

    public void IncrementMath(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: Math count may not be less than zero.");
        else
            math += amount;
    }

    public void IncrementMath()
    {
        IncrementMath(1);
        //DisplayMath();
    }

    public void IncrementCsCoding(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: CS coding count may not be less than zero.");
        else
            csCoding += amount;
    }

    public void IncrementCsCoding()
    {
        IncrementCsCoding(1);
        //DisplayCsCoding();
    }

    public void IncrementCsTheory(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid: CS Theory count may not be less than zero.");
        else
            csTheory += amount;
    }

    public void IncrementCsTheory()
    {
        IncrementCsTheory(1);
        //DisplayCsTheory();
    }

    /*
    public void DisplayEnglish()
    {
        englishTxt.text = "English : " + english;
    }

    public void DisplayMath()
    {
        mathTxt.text = "Math : " + math;
    }

    public void DisplayCsCoding()
    {
        csCodingTxt.text = "CS Coding : " + csCoding;
    }

    public void DisplayCsTheory()
    {
        csTheoryTxt.text = "CS Theory : " + csTheory;
    }
    */

}

