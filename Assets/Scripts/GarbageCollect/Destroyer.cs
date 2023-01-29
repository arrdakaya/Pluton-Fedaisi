using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public static Destroyer _instance;
    public int garbageCounter = 0;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Garbage")
        {
            garbageCounter++;
        }
    }
}
