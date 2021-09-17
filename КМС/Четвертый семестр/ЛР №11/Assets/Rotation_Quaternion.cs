using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Quaternion : MonoBehaviour
{
    Quaternion rot0 = new Quaternion();
    float Angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rot0 = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Angle++;
        Quaternion rotX = Quaternion.AngleAxis(Angle, Vector3.right);
        Quaternion rotZ = Quaternion.AngleAxis(Angle, Vector3.forward);
        transform.rotation = rot0 * rotX * rotZ;
    }
}
