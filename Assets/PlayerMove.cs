using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Vector3 pos;
    public float minFallSpeed;
    bool useParachute = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (useParachute == true)
        {
            rb.mass = 1;
            rb.drag = 2;
            rb.useGravity = false;
            var target_velocity = new Vector3(0f, -minFallSpeed, 0f);
            rb.AddForce(target_velocity * rb.mass * rb.drag / (1f - rb.drag * Time.fixedDeltaTime));
            Debug.Log(rb.velocity.magnitude);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y < 0)
        {
            useParachute = true;
        }
        else
        {
            rb.drag = 0;
            rb.useGravity = true;
            useParachute = false;
        }

        //Debug.Log(rb.velocity);
        //Debug.Log(pos);
    }
}
