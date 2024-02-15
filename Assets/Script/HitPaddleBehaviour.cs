using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPaddleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            //Debug.Log($"we hit {collision.gameObject.name}");

            BoxCollider bc = GetComponent<BoxCollider>();
            Bounds bounds = bc.bounds;
            float maxX = bounds.max.x;
            float minX = bounds.min.x;
            float ballX = collision.transform.position.x;

            //Debug.Log($"maxX = {maxX}, minY = {minX}");
            //Debug.Log($"x pos of ball is {collision.transform.position.x}");

            ballX -= minX;
            maxX -= minX;

            float r = (ballX / maxX - 0.5f) / 0.5f;

            Quaternion rotation;
            Vector3 bounceDirection;
            
            BallBehaviour b = collision.gameObject.GetComponent<BallBehaviour>();
            Rigidbody ball = collision.rigidbody;
            
            if (collision.transform.position.y > 0)
            {
                rotation = Quaternion.Euler(0f, 0f, 60f * r);
                bounceDirection = rotation * Vector3.down;
            }
            else
            {
                rotation = Quaternion.Euler(0f, 0f, -60f * r);
                bounceDirection = rotation * Vector3.up;
            }
            
            ball.AddForce(bounceDirection.normalized * b.speed, ForceMode.Force);
            b.force = ball.GetAccumulatedForce();
            b.speed *= b.acceleration;
            ball.AddTorque(new Vector3(Random.Range(30,60),Random.Range(30,60),Random.Range(30,60)), ForceMode.Acceleration);
        }
    }
}
