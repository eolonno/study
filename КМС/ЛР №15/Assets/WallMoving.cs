using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    public GameObject item;
    private float direction = 1f;

    public float movingSpeed = 1f;

    private void Start()
    {
        movingSpeed /= 10;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Tank")
        {
            var itemPos = item.gameObject.GetComponent<Transform>().position;
            if (itemPos.y >= 70)
                direction = -1f;
            else if(itemPos.y <= 14)
                direction = 1f;
            item.gameObject.GetComponent<Transform>().position =
                new Vector3(itemPos.x, itemPos.y + movingSpeed * direction, itemPos.z);
            
        }
    }
}
