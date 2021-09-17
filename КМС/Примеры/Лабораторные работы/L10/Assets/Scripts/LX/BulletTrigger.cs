using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour {

    public AudioClip reloadSound;
    public AudioClip boomSound;
    AudioSource mysourse = new AudioSource();

    private void Start()
    {
        mysourse = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            if (collision.rigidbody.tag.Equals("Bullet"))
            {
                Debug.Log("That was bullet");

                StartCoroutine(wait3seconds());

                this.GetComponent<Renderer>().material.color = new Color(Random.Range(0,1),0,0);

                mysourse.clip = boomSound;
                mysourse.Play();
                
            }
        }
        catch
        { }
    }


    IEnumerator wait3seconds()
    {
        yield return new WaitForSeconds(3f);

        mysourse.clip = reloadSound;
        mysourse.Play();

        this.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }
}
