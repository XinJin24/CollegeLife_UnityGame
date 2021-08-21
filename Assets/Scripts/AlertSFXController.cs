using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSFXController : MonoBehaviour
{

    [SerializeField] GameObject alertBox;
    [SerializeField] AudioSource alertSFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alertBox.activeInHierarchy)
        {
            alertSFX.Play();
        }
    }


}
