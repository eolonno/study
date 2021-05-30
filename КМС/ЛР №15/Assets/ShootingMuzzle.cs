using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMuzzle : MonoBehaviour
{
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        }
    }
}
