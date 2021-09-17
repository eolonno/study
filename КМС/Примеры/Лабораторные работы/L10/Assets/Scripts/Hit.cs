using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    //public GameObject objWithFaireSound;
    //AudioSource soundFaire;

    public float Bullet_Forward_Force;

    private void Start()
    {
        //soundFaire = objWithFaireSound.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Color color = new Color(Random.Range(0f, 1f), 0, 0);

        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = color;
            Destroy(gameObject);
            //soundFaire.Play();

        }
    }
}
