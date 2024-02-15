using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Score : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawn;
    private ScoreManager scoreM;

    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        scoreM = GetComponentInParent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {

            explosion.transform.position = other.transform.position;
            explosion.Play();
            Destroy(other.gameObject);
            GameObject b = Instantiate(ball,spawn.transform.position, Quaternion.identity);
            BallBehaviour ballB = b.GetComponent<BallBehaviour>();
            Vector3 direction;
            ballB.speed = ballB.baseSpeed;

            if (other.transform.position.y > 0)
            {
                direction = Vector3.down * -ballB.speed;
                scoreM.addPoint("player1");
            }
            else
            {
                direction = Vector3.down * ballB.speed;
                scoreM.addPoint("player2");
            }

            if (scoreM.getScore1() == 11  || scoreM.getScore2() == 11)
            {
                Destroy(b);
            }
            else
            {
                b.GetComponent<Rigidbody>().AddForce(direction);
                ballB.speed *= ballB.acceleration;
                b.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(30,60),Random.Range(30,60),
                    Random.Range(30,60)), ForceMode.Acceleration);
            }
        }
    }
}
