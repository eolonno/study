using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class BulletFlight : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public GameObject explosion;

    void Start()
    {
        Destroy(gameObject, 5f);   
    }

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up * bulletSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Goal" || other.gameObject.tag == "player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            Instantiate(explosion, other.transform.position, Quaternion.identity);

            var audioSource = other.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
