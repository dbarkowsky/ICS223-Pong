using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    private GameObject leftPaddle;
    private GameObject rightPaddle;
    [SerializeField]
    UIManager manager;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private int offset = 5;
    // Start is called before the first frame update
    void Start()
    {
        leftPaddle = GameObject.FindWithTag("PaddleLeft");
        rightPaddle = GameObject.FindWithTag("PaddleRight");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x < leftPaddle.transform.position.x - offset || ball.transform.position.x > rightPaddle.transform.position.x + offset)
        {
            if (ball.transform.position.x < leftPaddle.transform.position.x - offset)
            {
                scoreP2++;
            }
            else
            {
                scoreP1++;
            }
            Debug.Log(scoreP1 + ", " + scoreP2);
            manager.UpdateScore(scoreP1, scoreP2);
        }
    }
}
