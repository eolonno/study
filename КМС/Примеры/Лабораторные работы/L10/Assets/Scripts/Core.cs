using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {

    float coreSpeed = 0.2f;


    void Update () {
        transform.position += transform.TransformDirection(Vector3.back * coreSpeed);
	}
}
