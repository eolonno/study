using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CudeController : MonoBehaviour, IPointerClickHandler
{
    public float forse = 100f;
    public Camera camera;

    public void OnPointerClick(PointerEventData eventData)
    {
        float red = Random.Range(.0f, 1.0f);
        float green = Random.Range(.0f, 1.0f);
        float blue = Random.Range(.0f, 1.0f);

        Color color = new Color(red, green, blue);

        gameObject.GetComponent<Renderer>().material.color = color;

        Vector3 target = eventData.pointerPressRaycast.worldPosition;
        Vector3 collid = camera.transform.position;

        Vector3 newTarget = Vector3.Normalize(target - collid);

        collid = newTarget * forse;

        Rigidbody body = GetComponent<Rigidbody>();

        body.AddForceAtPosition(collid, target);

        ApplyForce(GetComponent<Rigidbody>());
    }

    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);
    }

}

