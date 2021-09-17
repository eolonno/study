using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColorChanger : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1);
        }
    }
}
