using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteractable npcInteractable)) {
                    npcInteractable.Interact();
                }
                if (collider.TryGetComponent(out CardInteractable cardInteractable))
                {
                    cardInteractable.Interact();
                }
                if (collider.TryGetComponent(out DoorInteractable doorInteractable))
                {
                    doorInteractable.ToggleDoor();
                }
                if (collider.TryGetComponent(out ShipInteraction shipInteraction))
                {
                    shipInteraction.Interact();
                }
                if (collider.TryGetComponent(out MachineInteraction machineInteraction))
                {
                    machineInteraction.Interact();
                }

            }
        }
       
    }
    public NPCInteractable GetInteractableObject()
    {
        float interactRange = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;
            }
           

        }
        return null;
    }
 
}
