using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Pluton : MonoBehaviour
{   
    public static Pluton _instance;
    public float counter;
    
    public Text textCounter;
    public GameObject player;

    void Start()
    {
         if(_instance==null)_instance=this;
        player=GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()

    {

       
    }
    private void OnTriggerStay(Collider other) {
        counter+=Time.deltaTime;
        if(counter>2){
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(GameManager._instance.IsFinish());
            player.transform.GetChild(6).SetParent(this.gameObject.transform);
            this.transform.GetChild(3).transform.position=this.gameObject.transform.GetChild(2).transform.position;
            this.transform.GetChild(3).transform.DOScale(new Vector3(44f,44f,44f),4f);
            
            
            
            
            

        }
    }
    private void OnTriggerExit(Collider other) {
        counter=0;
    }
}
