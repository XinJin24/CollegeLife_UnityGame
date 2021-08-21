using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
   
    [SerializeField] static int health =3;
    [SerializeField] static Text healthTxt;
    
    void Start()
    {
        
        healthTxt=GetComponent<Text>();
        healthTxt.text="Health: "+health;
    }
    void Update()
    {
        healthTxt.text="Health: "+health;
    }
    public static void DecrementHealth(int amount)
    {
        if(amount<0)
        {
            Debug.Log("Invalid, amount can not be less than zero");
        }
        else
        {
            health=health-amount;
        }
    }
    public static void DecrementHealth()
    {
        DecrementHealth(1);
    }
    public static void DisplayHealth()
    {
        healthTxt.text= "Health: "+ health; 
    }
    public static int getHealth()
    {
        return health;

    }
    public static void  setHealth(int heal)
    {
        health=heal;

    }
    /*
    public void DisplayScores()
    {
        scoreTxt.text="Scores: "+ scoreTxt;
    }
    */
}
