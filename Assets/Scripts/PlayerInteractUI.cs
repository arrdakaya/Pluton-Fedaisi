using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject textMessage;
    [SerializeField] private GameObject wakeuptext;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private Animator anim;

    private void Start()
    {
        OpenEyes();
    }
    private void Update()
    {
        if (playerInteract.GetInteractableObject()!=null) 
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        if(textMessage.activeInHierarchy == false)
        image.SetActive(true);
    }
    private void Hide()
    {
        image.SetActive(false);
        textMessage.SetActive(false);
    }
    private void OpenEyes()
    {
        StartCoroutine(wakeUpText());
        anim.Play("OpenEyes");
    }
    public IEnumerator wakeUpText()
    {
        yield return new WaitForSeconds(3);
        wakeuptext.SetActive(false);
    }
   
}
