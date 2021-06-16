using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingTest : MonoBehaviour
{
    private Camera camera;
    
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {

        //Raycasting
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2 + 70);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.GetComponent<Renderer>().material.color = Color.cyan;
                Vector3 pos = hit.point;
                sphere.transform.position = pos;
            }
        }
    }
}
