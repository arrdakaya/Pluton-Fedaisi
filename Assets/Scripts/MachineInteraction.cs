using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteraction : MonoBehaviour
{
    public GameObject Pluto;
    public GameObject FixText;
    public AudioSource Success;
    public AudioSource Quake;
    private bool isInteracted = false;

    public void Interact() {
        if (!isInteracted)
        {
            CameraShake._instance.CameraShakeCall();
            Quake.Play();
            StartCoroutine(MachineInteract());
            isInteracted = true;
        }
        
    }
    public IEnumerator MachineInteract()
    {
        Pluto.transform.DOMove(new Vector3(Pluto.transform.localPosition.x, 7.80f, Pluto.transform.localPosition.z), 4);
        yield return new WaitForSeconds(2.5f);
        FixText.SetActive(true);
        Success.Play();
        yield return new WaitForSeconds(2f);
        FixText.SetActive(false);

    }
}
