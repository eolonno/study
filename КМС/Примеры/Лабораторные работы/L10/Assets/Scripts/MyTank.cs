using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTank : MonoBehaviour
{
    float moveSpeed = 0.1f;
    float rotateSpeed = 1f;

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Input.GetAxis("Vertical"));
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotateSpeed, 0f);
    }
}
// // кнопки A D и 