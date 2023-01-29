using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour
{

    public GameObject door;
    public GameObject successScreen;
    private Animator animator;
    private bool isOpen;
    public AudioSource pressEsound;
    public AudioSource doorOpenSound;

    private void Awake()
    {
        animator = door.GetComponent<Animator>();
       
    }
    public void ToggleDoor()
    {
        if (CardInteractable._instance.cardActive)
        {
            StartCoroutine(Door());

        }

    }
    public IEnumerator Door()
    {
        successScreen.SetActive(true);
        pressEsound.Play();
        animator.SetBool("isOpen", true);
        yield return new WaitForSeconds(0.2f);
        doorOpenSound.Play();
    }
}
