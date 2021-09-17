using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public float m_Speed = 12f;                
    public float m_TurnSpeed = 180f;            

    private Rigidbody m_Rigidbody;              
    private float m_MovementInputValue;         
    private float m_TurnInputValue;

    AudioSource source_tank;
    public bool isMoving = false;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        source_tank = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_MovementInputValue = 1;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_MovementInputValue = -1;
            isMoving = true;
        }
        else
        {
            m_MovementInputValue = 0;
            isMoving = false;
        }


        if (Input.GetKey(KeyCode.A))
        {
            m_TurnInputValue = -1;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_TurnInputValue = 1;
            isMoving = true;
        }
        else
        {
            m_TurnInputValue = 0;
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
            isMoving = false;
        }

        Move();
        Turn();
        PlaySound();

    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    private void PlaySound()
    {
        if (isMoving && !source_tank.isPlaying)
            source_tank.Play();

        if (!isMoving)
            source_tank.Stop();
    }
}
