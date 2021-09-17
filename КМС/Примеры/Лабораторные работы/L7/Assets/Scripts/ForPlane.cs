using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPlane : MonoBehaviour {

    public GameObject genObject;


    public float genPosY = 5f;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newObject = genObject;

            newObject.transform.position = new Vector3(
                transform.position.x + Random.Range(-4, 4),
                transform.position.y + genPosY,
                transform.position.z + Random.Range(-4, 4));

            Instantiate(newObject);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 10);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 10);
        }
    }
    }
