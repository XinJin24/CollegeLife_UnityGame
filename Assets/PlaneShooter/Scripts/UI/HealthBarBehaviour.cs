using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color High;
    public Vector3 Offset;

    public void setHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value=health;
        slider.maxValue=maxHealth;
        
        if(health==0)
        {
            OnKilled();
        }
    }
    void Update()
    {
        slider.transform.position=Camera.main.WorldToScreenPoint(transform.parent.position+Offset);
    }
    void OnKilled()
    {
        slider.gameObject.SetActive(false);
    }
}
