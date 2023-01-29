using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardInteractable : MonoBehaviour
{
    public static CardInteractable _instance;
    public AudioSource cardTake;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public GameObject card;
    public GameObject cardCollider;
    public bool cardActive = false;
   
    public void Interact()
    {
        cardTake.Play();
        StartCoroutine(CardInteract());
    }
    IEnumerator CardInteract()
    {
        card.SetActive(false);
        cardActive = true;
        yield return new WaitForSeconds(3);
        cardCollider.SetActive(false);

    }
}
