using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3.0f;
    public float increase = 50.0f;

    private float maxSpeed = 15.0f;
    [SerializeField] private GameObject leftPaddle;
    [SerializeField] private GameObject rightPaddle;

    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch(Vector3 startingDirection)
    {
        rb.AddForce(startingDirection * speed * 100);
    }

    public void Reset()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            if (collision.gameObject == leftPaddle)
            {
                rb.AddForce(new Vector3(increase, 0, 0));
            }
            else if (collision.gameObject == rightPaddle)
            {
                rb.AddForce(new Vector3(-increase, 0, 0));
            }
        }
        Debug.Log(rb.velocity);
    }
}
