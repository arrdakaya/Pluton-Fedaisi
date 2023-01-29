using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject particle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(this.gameObject.transform.GetChild(0).gameObject!=null)this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale=0f;
        GameManager._instance.isFail=true;
        
       if(particle!=null) particle.GetComponent<ParticleSystem>().Play();
        this.gameObject.GetComponent<Rigidbody>().isKinematic=true;
    }
}
