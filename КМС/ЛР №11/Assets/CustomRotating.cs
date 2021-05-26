using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRotating : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        transform.RotateAround(new Vector3(10, 40, 3), 0.1f);
    }
}
