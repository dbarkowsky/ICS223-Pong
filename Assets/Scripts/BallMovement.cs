using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3.0f;

    private int offset = 5;
    private GameObject leftPaddle;
    private GameObject rightPaddle;

    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        leftPaddle = GameObject.FindWithTag("PaddleLeft");
        rightPaddle = GameObject.FindWithTag("PaddleRight");
        Launch(speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftPaddle.transform.position.x - offset || transform.position.x > rightPaddle.transform.position.x + offset)
        {
            Reset();
            Launch(speed);
        }
    }

    Vector3 GetRandomBallDirection()
    {
        int x = Random.value < 0.5f ? -1 : 1;
        int y = Random.value < 0.5f ? -1 : 1;

        return new Vector3(x, y, 0.0f);
    }

    public void Launch(float speed)
    {
        Vector3 startingDirection = GetRandomBallDirection();
        rb.AddForce(startingDirection * speed * 100);
    }

    private void Reset()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
