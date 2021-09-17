using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventsTest : MonoBehaviour, IPointerClickHandler
{
    public GameObject prefub;
    public void OnPointerClick(PointerEventData eventData)
    {
        Color color = new Color(Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f));
        GetComponent<Renderer>().material.color = color;

        Vector3 target = eventData.pointerPressRaycast.worldPosition;
        Vector3 collid = Camera.main.transform.position;
        float forse = 300f;

        Vector3 direction = target - collid;
        direction = direction.normalized;
        collid = direction * forse;

        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(collid, target);
    }
}
