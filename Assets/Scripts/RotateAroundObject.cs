using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject pivotPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotPoint.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
    }
}
