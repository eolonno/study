using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScale : MonoBehaviour
{
    float SIndex = 1f;
    bool Grow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SIndex < 5f && Grow)
        {
            SIndex += 0.01f;
            transform.localScale = new Vector3(SIndex, SIndex, SIndex);
        }
        else
        {
            Grow = false;
            SIndex -= 0.01f;
            transform.localScale = new Vector3(-SIndex, -SIndex, -SIndex);
            if (SIndex <= 1f)
                Grow = true;
        }
        
    }
}
