using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] Text dayTxt;
    [SerializeField] Text actionPointTxt;
    [SerializeField] Text healthTxt;
    [SerializeField] Text stressTxt;
    [SerializeField] Text learningTxt;
    [SerializeField] Text entertaimentTxt;

    [Range(0, 4)]
    [SerializeField] int actionPoint ;
    [Range(1, 15)]
    [SerializeField] int day ;
    [Range(0, 100)]
    [SerializeField] int health ;
    [Range(0, 100)]
    [SerializeField] int stress ;
    [Range(0, 100)]
    [SerializeField] int learning ;
    [Range(0, 100)]
    [SerializeField] int entertaiment;

    [Range(0, 1)]
    [SerializeField] float volume;
    

    int level;

    [SerializeField] GameObject HealthLowBox;
    [SerializeField] GameObject StressHighBox;
    [SerializeField] GameObject LearningAlertBox;
    [SerializeField] GameObject EntertaimentAlertBox;
    [SerializeField] GameObject SleepingAlertBox;
    [SerializeField] GameObject choiceOneEvent;
    [SerializeField] GameObject StressEvent;
    [SerializeField] GameObject FunEvent;
    [SerializeField] GameObject GameEvent;

    [SerializeField] GameObject CheatEvent;
    [SerializeField] GameObject HandleStressEvent;
    [SerializeField] GameObject HandleSickEvent;
    [SerializeField] GameObject SubjectPanel;
    [SerializeField] GameObject EntertaimentPanel;
    [SerializeField] GameObject VolumeSlider;

    public GameObject upArrowPrefab;
    public GameObject stressUpAnim;
    //public GameObject healthUpAnim;
    public GameObject learningUpAnim;
    public GameObject entertainmentUpAnim;

    public GameObject downArrowPrefab;
    public GameObject stressDownAnim;
    //public GameObject healthDownAnim;
    public GameObject learningDownAnim;
    public GameObject entertainmentDownAnim;

    [SerializeField] bool isEntDecremented = false;
    [SerializeField] bool isLearningDecremented = false;

    [SerializeField] Button LearningButton;
    [SerializeField] Button EntertaimentButton;
    [SerializeField] Button CounselingButton;
    [SerializeField] Button FnFButton;
    [SerializeField] Button VolumeButton;

    public static bool firstTimeHealth = true;
    public static bool firstTimeStress = true;
    public static bool firstTimeLearning = true;
    public static bool firstTimeEntertaiment = true;
    public static int randomEventDay;
    public static int gameEventDay;
    public static int funEventDay;
    public static int choiceOneEventDay;
    public static int HandleSickDay;
    public static int eventday;

    public static int HandleStressDay;

    public static int cheatingEventDay;
    public static bool firstTimeRandom = true;
    public static bool firstTimeFun = true;
    public static bool firstTimeCheat = true;
    public static bool firstTimeGame = true;

    public static bool firstTimeHandleStress = true;
    public static bool firstTimeSick = true;


    void Awake(){
      //randomEventDay = Random.Range(2, 16);//a random day from 2 - 15 an event would occur
      randomEventDay = 8;
      Debug.Log("stress Day: "+randomEventDay);
      funEventDay = 5;
      Debug.Log("funEventDay: "+funEventDay);
      choiceOneEventDay = 6;
      Debug.Log("choiceOneEventDay: "+choiceOneEventDay);
      cheatingEventDay = 4;
      Debug.Log("cheatingEventDay: "+cheatingEventDay);
      gameEventDay = 12;
      Debug.Log("game Day: " + gameEventDay);
      HandleSickDay = 7;
      HandleStressDay= 3;
    }


    // Start is called before the first frame update
    void Start()
    {
        actionPoint=PersistentData.Instance.GetActionPoint();
        health=PersistentData.Instance.GetHealth();
        stress=PersistentData.Instance.GetStress();
        entertaiment=PersistentData.Instance.GetEntertainment();
        day=PersistentData.Instance.GetDay();
        learning=PersistentData.Instance.GetLearning();
        volume=PersistentData.Instance.GetVolume();



        level = SceneManager.GetActiveScene().buildIndex;
        DisplayDay();
        DisplayActionPoint();
        DisplayHealth();
        DisplayStress();
        DisplayLearning();
        DisplayEntertaiment();
    }

    // Update is called once per frame
    void Update()
    {
        PersistentData.Instance.SetActionPoint(actionPoint);
        PersistentData.Instance.SetDay(day);
        PersistentData.Instance.SetEntertainment(entertaiment);
        PersistentData.Instance.SetHealth(health);
        PersistentData.Instance.SetLearning(learning);
        PersistentData.Instance.SetStress(stress);
        

        if(health <= 0)
        {        
            SceneManager.LoadScene("DeadScene");
            PersistentData.Instance.ResetEverything();
        }

        if (randomEventDay == day
            && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false))
        {
            RandomEventCaller();
        }

        if (gameEventDay == day
            && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false))
        {
            GameEventCaller();
        }

        if (choiceOneEventDay == day
            && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false))
        {
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            choiceOneEvent.SetActive(true);
        }
        if(cheatingEventDay == day
            && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false)){
            CheatingEventCaller();
        }

         if(funEventDay == day
            && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false)){
            FunEventCaller();
        }

        if(HandleStressDay==day
         && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false)){
          HandleStressCaller();
        }

        if(HandleSickDay==day
         && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false)){
          HandleSickCaller();
        }

    }

    public void DecrementActionPoint(int amount)
    {
        if (actionPoint==1)
        {
            ResetActionPoint();
            IncrementDay();
        }
        else
        {
            actionPoint -= amount;
        }

        DisplayActionPoint();

    }

    public void DecrementActionPoint()
    {
        DecrementActionPoint(1);
    }

    public void IncrementDay(int amount)
    {
        day += amount;
        DisplayDay();

        /*if(randomEventDay == day){
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            StressEvent.SetActive(true);
        }*/
         /*if(funEventDay == day){
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            FunEvent.SetActive(true);
        }*/
         if(choiceOneEventDay == day 
            && (SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false)){
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            choiceOneEvent.SetActive(true);
        }
        if (day >= 15 && learning >= 65)
            SceneManager.LoadScene("ExamScene");
        else if (day >= 15 && learning < 65)
        {
            

            SceneManager.LoadScene("NotGraduationScene");
        }

        if(day == 2)
        {
            SleepingAlertBox.SetActive(true);
        }

        IncrementHealth();
        DecrementStress(5);

    }

    public void IncrementDay()
    {
        IncrementDay(1);
    }

    public void DecrementHealth(int amount)
    {
        if(health > 0)
        {
            health -= amount;
            health = Mathf.Clamp(health, 0, 100);
            //Instantiate(downArrowPrefab, healthDownAnim.transform.position, Quaternion.identity);
        }
 
        DisplayHealth();

        if (health <= 0)
        {
            Debug.Log("You Died");
        }

        if(health <= 20)
        {
            if (firstTimeHealth == true) //&& EntertaimentButton.interactable == true
                //&& LearningButton.interactable == true)
            {
                HealthLowBox.SetActive(true);
                firstTimeHealth = false;
                LearningButton.interactable = false;
                EntertaimentButton.interactable = false;
            }
        }

    }

    public void DecrementHealth()
    {
        DecrementHealth(10);
    }

    public void IncrementHealth(int amount)
    {
        health += amount;
        DisplayHealth();
        //Instantiate(upArrowPrefab, healthUpAnim.transform.position, Quaternion.identity);
    }

    public void IncrementHealth()
    {
        if (health < 100)
            IncrementHealth(2);

    }

    public void DecrementStress(int amount)
    {
        if(stress > 0)
        {
            stress -= amount;
            stress = Mathf.Clamp(stress, 0, 100);
            Instantiate(downArrowPrefab, stressDownAnim.transform.position, Quaternion.identity);
        }

        DisplayStress();
    }

    public void DecrementStress()
    {
        DecrementStress(10);
    }

    public void IncrementStress(int amount)
    {
        stress += amount;
        stress = Mathf.Clamp(stress, 0, 100);
        DisplayStress();
        Instantiate(upArrowPrefab, stressUpAnim.transform.position, Quaternion.identity);
        Debug.Log("Up Arrow animation on");

        if (stress >= 100)
        {
            DecrementHealth();
            //DecrementStress(15);
        }

        if (stress >= 80)
        {
            if (firstTimeStress == true) //&& EntertaimentButton.interactable == true
                //&& LearningButton.interactable == true)
            {
                StressHighBox.SetActive(true);
                firstTimeStress = false;
                LearningButton.interactable = false;
                EntertaimentButton.interactable = false;
            }
        }

    }

    public void IncrementStress()
    {
        IncrementStress(10);
    }

    public void IncrementLearning(int amount)
    {
        learning += amount;
        learning = Mathf.Clamp(learning, 0, 100);
        DisplayLearning();
        Instantiate(upArrowPrefab, learningUpAnim.transform.position, Quaternion.identity);

        if (firstTimeLearning == true) //&& LearningButton.interactable == true
            //&& EntertaimentButton.interactable == true)
        {
            LearningAlertBox.SetActive(true);
            firstTimeLearning = false;
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
        }

        IncrementStress();
        DecrementEntertaiment(5);
    }

    public void IncrementLearning()
    {
        IncrementLearning(5);
    }

    public void DecrementLearning(int amount)
    {
        learning -= amount;
        isLearningDecremented = true;
        if (learning >= 0 && isLearningDecremented == true)
        {
            Instantiate(downArrowPrefab, learningDownAnim.transform.position, Quaternion.identity);
            isLearningDecremented = false;
        }
        learning = Mathf.Clamp(learning, 0, 100);
        DisplayLearning();
        //Instantiate(downArrowPrefab, learningDownAnim.transform.position, Quaternion.identity);
    }

    public void DecrementLearning()
    {
        DecrementLearning(5);
    }

    public void DecrementEntertaiment(int amount)
    {
        entertaiment -= amount;
        isEntDecremented = true;
        if (entertaiment >= 0 && isEntDecremented == true)
        {
            Instantiate(downArrowPrefab, entertainmentDownAnim.transform.position, Quaternion.identity);
            isEntDecremented = false;

        }
        entertaiment = Mathf.Clamp(entertaiment, 0, 100);
        DisplayEntertaiment();

        if (entertaiment <= 0)
        {
            IncrementStress(5);
        }

    }

    public void DecrementEntertaiment()
    {
        DecrementEntertaiment(10);
    }

    public void IncrementEntertaiment(int amount)
    {
        entertaiment += amount;
        entertaiment = Mathf.Clamp(entertaiment, 0, 100);
        DisplayEntertaiment();
        Instantiate(upArrowPrefab, entertainmentUpAnim.transform.position, Quaternion.identity);
        DecrementStress(15);
        DecrementLearning();

        if (firstTimeEntertaiment == true) //&& EntertaimentButton.interactable == true
            //&& LearningButton.interactable == true)
        {
            EntertaimentAlertBox.SetActive(true);
            firstTimeEntertaiment = false;
            EntertaimentButton.interactable = false;
            LearningButton.interactable = false;
        }

    }

    public void IncrementEntertaiment()
    {
        if(entertaiment <= 90)
        IncrementEntertaiment(10);
    }

    public void DisplayHealth()
    {
        healthTxt.text = "Health : " + health;
    }

    public void DisplayStress()
    {
        stressTxt.text = "Stress : " + stress;
    }

    public void DisplayLearning()
    {
        learningTxt.text = "Learning : " + learning;
    }

    public void DisplayEntertaiment()
    {
        entertaimentTxt.text = "Entertaiment : " + entertaiment;
    }

    public void DisplayDay()
    {
        dayTxt.text = "Day " + day;
    }

    public void DisplayActionPoint()
    {
        actionPointTxt.text = "Action Point - " + actionPoint;
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 1);
    }

    public void Advance2Level()
    {
        SceneManager.LoadScene(level + 2);
    }

    public int ReturnDay()
    {
        return day;
    }

    public int ReturnActionPoint()
    {
        return actionPoint;
    }

    public void ResetActionPoint()
    {
        actionPoint = 4;
    }

    public void LearningInteractable()
    {
        LearningButton.interactable = true;
    }

    public void EntertaimentInteractable()
    {
        EntertaimentButton.interactable = true;
    }

    public void InteractableToFalse()
    {
        LearningButton.interactable = false;
        EntertaimentButton.interactable = false;
    }

    public void InteractableToTrue()
    {
        LearningButton.interactable = true;
        EntertaimentButton.interactable = true;
    }

    public void RandomEventCaller()
    {
            if (randomEventDay == day && firstTimeRandom == true &&
            SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false)
            {
                LearningButton.interactable = false;
                EntertaimentButton.interactable = false;
                StressEvent.SetActive(true);
                firstTimeRandom = false;
            }
    }

    public void GameEventCaller()
    {
        if (gameEventDay == day && firstTimeGame == true &&
        SubjectPanel.activeInHierarchy == false && EntertaimentPanel.activeInHierarchy == false)
        {
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            GameEvent.SetActive(true);
            firstTimeGame = false;
        }
    }

    public void FunEventCaller()
    {
        if (funEventDay == day && firstTimeFun == true)
        {
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            FunEvent.SetActive(true);
            firstTimeFun = false;
        }
    }

    public void setCounselingButtonFalse()
    {
        CounselingButton.interactable = false;
    }

    public void setFnFButtonFalse()
    {
        FnFButton.interactable = false;
    }
    
    public void setVolumeSlider()
    {
        if(VolumeSlider.activeInHierarchy == true)
        {
            VolumeSlider.SetActive(false);
        }
        else
        {
            VolumeSlider.SetActive(true);
        }
    }
    public void HandleStressCaller()
    {
        if (HandleStressDay == day && firstTimeHandleStress == true)
        {
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            HandleStressEvent.SetActive(true);
            firstTimeHandleStress = false;
        }
    }
    public void HandleSickCaller()
    {
        if (HandleSickDay == day && firstTimeSick == true)
        {
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            HandleSickEvent.SetActive(true);
            firstTimeSick = false;
        }
    }
    public void CheatingEventCaller()
    {
        if (cheatingEventDay == day && firstTimeCheat == true)
        {
            LearningButton.interactable = false;
            EntertaimentButton.interactable = false;
            CheatEvent.SetActive(true);
            firstTimeCheat = false;
        }
    }

    public void cheat()
    {
        int success =  Random.Range(0, 2);
        if(success == 0)
        {
            Debug.Log("Cheated but not caught");
        }
        else{
            Debug.Log("Cheat and caught");
            SceneManager.LoadScene("NotGraduationScene");
            firstTimeCheat=true;
        }
    }

    public void loadShooterGame()
    {
        SceneManager.LoadScene("directions");
    }

}
