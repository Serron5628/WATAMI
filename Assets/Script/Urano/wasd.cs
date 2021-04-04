using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
        */
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0.0f, 0.0f, -speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
        }
    }
}
