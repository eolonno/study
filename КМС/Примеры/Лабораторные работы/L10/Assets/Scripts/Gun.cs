using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    float angle = 90;
    float min = 80;
    float max = 120;

    void Update() {
        if (Input.GetAxis("Mouse Y") > 0 && angle > min)
        {
            transform.localRotation = Quaternion.Euler(angle--, 0, 0); // поворачиваем ствол со смещением
        }
        if (Input.GetAxis("Mouse Y") < 0 && angle < max)
        {
            transform.localRotation = Quaternion.Euler(angle++, 0, 0);
        }
    }
}
