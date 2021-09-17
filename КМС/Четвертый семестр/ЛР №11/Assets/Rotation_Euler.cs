using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Euler : MonoBehaviour
{
    float Angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(1, 0, 1));
        Angle += 1f;
        transform.eulerAngles = new Vector3(Angle, 0, Angle);
    }
}
