using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 0.05f,
                                         transform.position.y + 0.07f,
                                         transform.position.x + 0.03f);
    }
}
