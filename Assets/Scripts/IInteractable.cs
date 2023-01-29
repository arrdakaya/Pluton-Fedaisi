using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractable:MonoBehaviour
{
    public GameObject pressE;
    private void OnTriggerEnter(Collider other)
    {
            pressE.SetActive(true);
      
    }
    private void OnTriggerExit(Collider other)
    {

        pressE.SetActive(false);
    }
    

}
