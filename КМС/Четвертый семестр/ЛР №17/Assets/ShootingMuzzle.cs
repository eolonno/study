using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMuzzle : MonoBehaviour
{
    public GameObject Bullet;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float spawnPoint = gameObject.GetComponent<Renderer>().bounds.size.z;
            Vector3 muzzleForward = transform.position + transform.TransformDirection(Vector3.forward * spawnPoint);
            GameObject newBullet = Instantiate(Bullet,muzzleForward,transform.rotation);
            var MuzzleEulerAngles = transform.rotation;
            newBullet.transform.rotation = MuzzleEulerAngles;
            newBullet.transform.Rotate(new Vector3(90,0,0));
            
            var audioSource = newBullet.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
