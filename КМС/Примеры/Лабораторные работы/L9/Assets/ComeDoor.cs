using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeDoor : MonoBehaviour {

    public Light lamp;

    private void Start()
    {
        lamp.intensity = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        lamp.intensity = 32;
    }

    private void OnTriggerExit(Collider other)
    {
        lamp.intensity = 0;
    }
}
