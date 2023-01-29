using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hook : MonoBehaviour
{
    public bool hook;
    public bool grappedSomewhere;
    public Camera cameramain;
    public GameObject obiRope;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&hook&&!grappedSomewhere){
            Debug.Log("sdfs12312d");
            
                RaycastHit hit;
                
                Ray ray = cameramain.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    

                        Debug.Log(hit.collider.gameObject);
                        this.gameObject.transform.DOJump(hit.collider.transform.position,10f,1,2f);
                        this.gameObject.GetComponent<FixedJoint>().connectedBody=hit.collider.gameObject.transform.GetComponent<Rigidbody>();
                        
                       // hit.collider.gameObject.transform.SetParent(this.gameObject.transform.parent);
                    
                }
        }else if(Input.GetMouseButtonDown(0)&&hook&&grappedSomewhere){

        }
    }
}
