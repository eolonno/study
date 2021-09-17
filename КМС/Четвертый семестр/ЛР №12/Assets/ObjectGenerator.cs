using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    float minX,
        maxX,
        minZ,
        maxZ,
        ObjectY;
    bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        var rend = gameObject.GetComponent<MeshRenderer>();
        minX = rend.bounds.min.x;
        minZ = rend.bounds.min.z;
        maxX = rend.bounds.max.x;
        maxZ = rend.bounds.max.z;

        ObjectY = gameObject.transform.position.y + Random.Range(3, 20);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            float ObjectX = Random.Range(minX, maxX);
            float ObjectZ = Random.Range(minZ, maxZ);

            var Object = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.transform.position = new Vector3(ObjectX, ObjectY, ObjectZ);
            Object.AddComponent<Rigidbody>();
        }
        if(Input.GetKey(KeyCode.W) && !isRotating)
        {
            isRotating = true;
            StartCoroutine(ThrowOff());
        }
    }
    IEnumerator ThrowOff()
    {
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(-1, 0, 0), Space.World);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(1, 0, 0), Space.World);
            yield return new WaitForSeconds(0.01f);
        }
        isRotating = false;
    }
}
