using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject prefub;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(1f, 10.0f), Random.Range(-5.0f, 5.0f));
            Instantiate(prefub, position, Quaternion.identity);

        }
    }
}
