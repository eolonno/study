using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaireController : MonoBehaviour
{

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public GameObject gun;

    public GameObject objWithFaireSound;
    AudioSource soundFaire;

    public float Bullet_Forward_Force;

    private void Start()
    {
        soundFaire = objWithFaireSound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet;
            bullet = Instantiate(Bullet, Bullet_Emitter.transform.position, gun.transform.localRotation) as GameObject;

            bullet.transform.Rotate(Vector3.left * 90);

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = bullet.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(gun.transform.forward * (Bullet_Forward_Force));

            Destroy(bullet, 4.0f);

            soundFaire.PlayOneShot(soundFaire.clip);
        }
    }
}

