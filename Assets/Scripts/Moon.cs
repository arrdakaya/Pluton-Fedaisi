using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Moon : MonoBehaviour
{
    public static Moon _instance;
public float counter;
public GameObject pluton;
public Text textCounter;

public GameObject player;
 void Start()
    {
        if(_instance==null)_instance=this;
        player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void OnTriggerStay(Collider other) {
        counter+=Time.deltaTime;
        
        if(counter>2){
            MoonResize();
            pluton.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
    public void MoonResize(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.GetComponent<SphereCollider>().enabled=false;
        this.gameObject.transform.DOMove(player.transform.position,4f);
        this.gameObject.transform.DOScale(new Vector3(1f,1f,1f),4f).OnStepComplete(()=>this.gameObject.transform.SetParent(player.transform));
        
    }
}
