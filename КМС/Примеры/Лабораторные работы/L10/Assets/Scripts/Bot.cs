using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {

    public float moveSpeed = 10f;
    public float rotBodySpaeed = 30f;
    public float rotHeadSpeed = 30f;
    public float bulletForce = 1000f;

    public GameObject body;
    public GameObject head;
    public GameObject gun;
    public GameObject bulletEmitter;

    public GameObject bulletPrefab;
   // public GameObject explosion;

    public bool canShoot = true;
    public int life = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("core"))
        {
            life -= 1;
        }

        if (life <= 0)
        {
            Destroy(head);
            Destroy(this);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        FindPlayer(other);
    }


    void FindPlayer(Collider colider)
    {
        if (colider.tag.Equals("Player"))
        {
            float distance = Vector3.Distance(colider.transform.position, transform.position);
            Vector3 playerDirection = colider.transform.position - transform.position;
            Quaternion newRot = Quaternion.LookRotation(playerDirection);

            if (distance < 40)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * rotBodySpaeed);
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, colider.transform.position.x, Time.deltaTime * moveSpeed), transform.position.y, Mathf.Lerp(transform.position.z, colider.transform.position.z, Time.deltaTime * moveSpeed));
            }

            head.transform.rotation = Quaternion.Slerp(head.transform.rotation, newRot, Time.deltaTime * rotHeadSpeed);

            RaycastHit hit = new RaycastHit(); //переменная для записи объекта попадания
                                               //выпускаем луч из башни в направлении относительно ее – вперед.
            hit.distance = 30;
            if (Physics.Raycast(head.transform.position, head.transform.TransformDirection(Vector3.forward), out hit))
            {
                if ((hit.transform.tag.Equals("Player")) && canShoot)
                {
                    StartCoroutine(botShoot()); //запускаем корутину для выстрела вражеского танка
                }

               // Debug.Log(hit.transform.tag);
            }

        }

    }

    IEnumerator botShoot()
    {
        canShoot = false;   

        GameObject bullet;
        bullet = Instantiate(bulletPrefab, bulletEmitter.transform.position, gun.transform.localRotation) as GameObject;

        bullet.transform.Rotate(Vector3.left * 90);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = bullet.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(gun.transform.forward * (-bulletForce));

        Debug.Log("Try to kill");

        Destroy(bullet, 10.0f);

        yield return new WaitForSeconds(3f); //ждем 3 секунды (время перезарядки)
        canShoot = true; //указываем, что можем сделать новый выстрел
    }

}
