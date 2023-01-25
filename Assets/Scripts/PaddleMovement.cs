using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 9.0f;

    // Assumed left paddle, asign "VerticalP2" in Inspector if right paddle
    [SerializeField]
    private string vertInputAxis = "VerticalP1";

    private float vertInput;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertInput = Input.GetAxis(vertInputAxis);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, vertInput, 0) * speed * Time.deltaTime;
        Vector3 newPos = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + movement.y, -5, 5), transform.position.z);
        rb.MovePosition(newPos);
    }
}
