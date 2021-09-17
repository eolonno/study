using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotation : MonoBehaviour {

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
        {
            box.transform.Rotate(new Vector3(0,0,90), 90 * Time.deltaTime);
        }
;    }
}
