using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public GameObject particle,particle1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            
            
            RaycastHit hit;
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                GameObject new1=Instantiate(particle.gameObject,this.gameObject.transform.position,Quaternion.identity);
                Vector3 direction=this.gameObject.transform.position+500*ray.direction;
            new1.transform.DOMove(direction,1f);
            Destroy(new1.gameObject,0.6f);
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.transform.gameObject.tag=="Garbage"){
                        
                        GameObject new2=Instantiate(particle1.gameObject,hit.collider.transform.gameObject.transform.position,Quaternion.identity);
                        new2.GetComponent<ParticleSystem>().Play();
                        Destroy(new2,0.3f);
                        
                        Destroy(hit.collider.transform.gameObject);
                        GameManager._instance.garbageCount+=0.5f;
                    }

                        
                        
                    
                }
        }
    }
}
