using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject npcText;
    public GameObject buttonImage;
    public void Interact()
    {
        npcText.SetActive(true);
        buttonImage.SetActive(false);

    }
    
    
   
}
