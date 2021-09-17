using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float LifeTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTime > 0)
        {
            LifeTime -= Time.deltaTime;
            if (LifeTime <= 0)
            { Destruction(); }
        }
    }
    void Destruction() { Destroy(gameObject); }
}
