using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float destroySec = 1f;
    public void animEndDestroy()
    {
        Destroy(gameObject, destroySec);
    }
}
