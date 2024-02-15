using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject paddle1;
    public GameObject paddle2;
    private Rigidbody rb1;
    private Rigidbody rb2;
    public float paddleForce = 80f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb1 = paddle1.GetComponent<Rigidbody>();
        rb2 = paddle2.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalValue1 = Input.GetAxis("Paddle1");
        float horizontalValue2 = Input.GetAxis("Paddle2");
        
        Vector3 force1 = Vector3.right * horizontalValue1;
        Vector3 force2 = Vector3.right * horizontalValue2;
        
        rb1.AddForce(force1 * paddleForce, ForceMode.Force);
        rb2.AddForce(force2 * paddleForce, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}
