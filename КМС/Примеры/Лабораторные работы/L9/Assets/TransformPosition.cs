using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPosition : MonoBehaviour {

    public GameObject box;

    bool isEvent = false;

    void OnTriggerEnter(Collider other)
    {
        isEvent = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isEvent = false;
    }

    public void Update()
    {
        if (isEvent)
        box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y + 1 * Time.deltaTime, box.transform.position.z);
    }
}
