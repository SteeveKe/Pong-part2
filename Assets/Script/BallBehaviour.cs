using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallBehaviour : MonoBehaviour
{
    public float acceleration = 2f;
    public float speed; 
    public float baseSpeed = 300f;
    public Vector3 force;
    //public ParticleSystem particle;

    // Start is called before the first frame update
    
    void Start()
    {
        ///particle = FindObjectsByType<ParticleSystem>();
        /*
        speed = baseSpeed;
        
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 direction;

        if (Random.Range(0,2) == 1)
        {
            direction = Vector3.down * speed;
        }
        else
        {
            direction = Vector3.down * -speed;
        }
        
        rb.AddForce(direction);
        speed *= acceleration;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        particle.transform.position = collision.contacts[0].point;
        particle.Play();
    }
    */
}
