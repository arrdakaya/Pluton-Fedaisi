using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    public Transform target;
    public GameObject[] myObj;
    public GameObject parent;
    public Transform[] garbageSpawn;
    public float speed = 4f;
    public int garbageNumber = 0;
    GameObject instantiatedGarbage;


    public static GarbageCollector _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


// Start is called before the first frame update
void Start()
    {
        StartCoroutine("GarbageSpawn");

    }
   


    // Update is called once per frame

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine("GarbageSpawn");
        Debug.Log("??k??");

    }
   /* private void OnTriggerStay(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            foreach (Transform child in parent.GetComponentsInChildren<Transform>())
            {
                if (child)
                {
                    child.transform.LookAt(target.position);
                    child.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
                }
            }

        }
    }*/
    IEnumerator GarbageSpawn()
    {
        int counter = 0;
            if (counter < 8)
            {
            
                yield return new WaitForSeconds(1);
                int garbageSpawnPoint = Random.Range(0, 4);
                int garbageType = Random.Range(0, 3);
                Vector3 spawnPositionInUnitCircle = new Vector3(Random.onUnitSphere.x * 30, Random.onUnitSphere.y * 30, Random.onUnitSphere.z * 30);

                instantiatedGarbage = (GameObject) Instantiate(myObj[garbageType], this.gameObject.transform.GetChild(0).transform.position+spawnPositionInUnitCircle, Quaternion.identity, parent.transform);
                counter++;


        }




    }



}
