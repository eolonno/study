using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {

        //Выстрел при нажатии на левую кнопку мыши
        // if (Input.GetMouseButtonDown(0))
        // {
        //     RaycastHit hit;
        //     Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
        //
        //     if (Physics.Raycast(Camera.main.transform.position, fwd, out hit, 100.0f))//Есть пересечение
        //     {
        //         var Object = hit.collider.GetComponent<Rigidbody>();
        //         if (Object != null && Object.name != "Terrain")
        //         {
        //             Vector3 target = Object.position;
        //             Vector3 collid = Camera.main.transform.position;
        //             float forse = 300f;
        //
        //             Vector3 direction = target - collid;
        //             direction = direction.normalized;
        //             collid = direction * forse;
        //
        //             Object.AddForceAtPosition(collid, target);
        //         }
        //     }
        // }
    }
}
