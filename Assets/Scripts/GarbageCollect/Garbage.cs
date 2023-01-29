using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Garbage : MonoBehaviour
{
    private GameObject player;
    private bool state;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void Update()
    {
        
    }
    public void ToDestination()
    {
        if (!state)
        {
            //this.gameObject.transform.DOMove(player.transform.position, 4f).OnStepComplete(()=>Destroy(this.gameObject));
            state = true;
            
        }
        
    }
}
