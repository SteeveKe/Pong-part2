using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        GameObject b = Instantiate(ball,transform.position, Quaternion.identity);
        BallBehaviour ballB = b.GetComponent<BallBehaviour>();
        ballB.speed = ballB.baseSpeed;
        
        Vector3 direction;
        direction = Vector3.down * ballB.speed;

        b.GetComponent<Rigidbody>().AddForce(direction);
        ballB.speed *= ballB.acceleration;
        b.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(30,60),Random.Range(30,60),
            Random.Range(30,60)), ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
