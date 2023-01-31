using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private GameObject ball;
    [SerializeField] private GameObject leftPaddle;
    [SerializeField] private GameObject rightPaddle;
    [SerializeField] private BallMovement ball;
    [SerializeField] UIManager manager;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private int offset = 5;
    // Start is called before the first frame update
    void Start()
    {
        manager.UpdateScore(0, 0);
        ball.Launch(GetRandomBallDirection());
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
            ball.Reset();
            ball.Launch(GetRandomBallDirection());
        }
    }

    Vector3 GetRandomBallDirection()
    {
        int x = Random.value < 0.5f ? -1 : 1;
        int y = Random.value < 0.5f ? -1 : 1;

        return new Vector3(x, y, 0.0f);
    }
}
