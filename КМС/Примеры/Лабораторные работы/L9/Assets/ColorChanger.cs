using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Light lamp;
    public Color color;

    Color baseColor;

    private void Start()
    {
        baseColor = lamp.color;
    }

    void OnTriggerEnter(Collider other)
    {
        lamp.color = color;
    }

    private void OnTriggerExit(Collider other)
    {
        lamp.color = baseColor;
    }
}
