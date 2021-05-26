using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_GetAxis : MonoBehaviour
{
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(x, 0, z);
        float y = Mathf.Clamp(-Input.GetAxis("Mouse X"), -90, 90);
        x = Mathf.Clamp(Input.GetAxis("Mouse Y"), -90, 90);
        transform.Rotate(x, y, 0);   
    }
}
