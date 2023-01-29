using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    public AudioSource doorOpen;
    private void Start()
    {
        doorAnim = this.transform.parent.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        doorOpen.Play();
        doorAnim.SetBool("isOpening", true);
    }
    private void OnTriggerExit(Collider other)
    {
        doorAnim.SetBool("isOpening", false);

    }

}
