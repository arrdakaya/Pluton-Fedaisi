using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipInteraction : MonoBehaviour
{
    private Animator animator;
    private Animator closeEyeAnimator;
    public GameObject upperDoor;
    public GameObject closeEyes;
    public AudioSource doorOpen;

    private void Awake()
    {
        animator = upperDoor.GetComponent<Animator>();
        closeEyeAnimator = closeEyes.GetComponent<Animator>();
    }
    public void Interact()
    {
        doorOpen.Play();
        StartCoroutine(OpenDoor());
    }
    public IEnumerator OpenDoor()
    {
        animator.SetBool("isOpen", true);
        yield return new WaitForSeconds(3);
        closeEyes.SetActive(true);
        closeEyeAnimator.Play("CloseEyes");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);

    }
}
