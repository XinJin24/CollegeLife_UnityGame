using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int Health=100;
    [SerializeField] int Stress=0;
    [SerializeField] int Learning=0;
    [SerializeField] int Entertainment=0;
    [SerializeField] int Day=1;
    [SerializeField] float Volume=1f;
    [SerializeField] int ActionPoint=4;


    public static PersistentData Instance;

    // Start is called before the first frame update
    void Start()
    {
        Health=100;
        Stress=0;
        Learning=0;
        Entertainment=0;
        Day=1;
    
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public  void SetHealth(int heal)
    {
        Health=heal;
    }

    public void SetStress(int str)
    {
        Stress=str;
    }

    public void SetLearning(int Lear)
    {
        Learning=Lear;
        
    }
    public void SetEntertainment(int Ent)
    {
        Entertainment=Ent;
    }
    public void SetDay(int da)
    {
        Day=da;
    }
    public int GetHealth()
    {
        return Health;
    }

    public int GetStress()
    {
        return Stress;
    }

    public int GetLearning()
    {
        return Learning;
        
    }
    public int GetEntertainment()
    {
        return Entertainment;
    }
    public int GetDay()
    {
        return Day;
    }
    // Update is called once per frame
    public float GetVolume()
    {
        return Volume;
    }
    public void SetVolume(float vol)
    {
        Volume=vol;
    }
    public int GetActionPoint()
    {
        return ActionPoint;
    }
    public void SetActionPoint(int act)
    {
        ActionPoint=act;
    }

    void Update()
    {
        
    }
    public void ResetEverything()
    {
        Health=100;
        Stress=0;
        Learning=0;
        Entertainment=0;
        Day=1;
        ActionPoint=4;
    }
}
