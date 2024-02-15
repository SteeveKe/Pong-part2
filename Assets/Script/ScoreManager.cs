using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text ScoreText1;
    public TMP_Text ScoreText2;
    private int score1;
    private int score2;
    public GameObject ball;
    public GameObject button;
    
    public int getScore1()
    {
        return score1;
    }
    
    public int getScore2()
    {
        return score2;
    }

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        ScoreText1.text = "0";
        ScoreText2.text = "0";
        score1 = 0;
        score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoint(string player)
    {
        if (player.Equals("player1"))
        {
            score1 += 1;
            ScoreText1.text = score1.ToString();
            
            if (score1 >= 11)
            {
                button.SetActive(true);
                ScoreText1.text = "WINNER";
                ScoreText2.text = "LOOSER";
            }
        }
        else
        {
            score2 += 1;
            ScoreText2.text = score2.ToString();
            
            if (score2 >= 11)
            {
                button.SetActive(true);
                ScoreText1.text = "LOOSER";
                ScoreText2.text = "WINNER";
            }
        }
    }

    public void OnClickRestart()
    {
        button.SetActive(false);
        ScoreText1.text = "0";
        ScoreText2.text = "0";
        score1 = 0;
        score2 = 0;
        
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
}
