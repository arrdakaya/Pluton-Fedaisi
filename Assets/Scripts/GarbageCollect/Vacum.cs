using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Vacum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Garbage") {
            Destroy(other.gameObject,3.1f);

          other.gameObject.transform.DOMove(this.gameObject.transform.position,3f).OnStepComplete(() => other.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<ParticleSystem>().Play());
}
      
    }

}
