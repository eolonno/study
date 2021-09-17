using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(x, 0, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Color randColor = new Color(Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f));
        collision.gameObject.GetComponent<Renderer>().material.color = randColor;
    }
}
