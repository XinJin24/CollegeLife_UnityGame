using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musicplay : MonoBehaviour
{
    public Slider slider;


    private void Start()
    {
        
        
        slider.value=PersistentData.Instance.GetVolume();
    }

    private void Update()
    {
        PersistentData.Instance.SetVolume(slider.value);
    }

    

}
    