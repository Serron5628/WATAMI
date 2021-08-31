using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDonguriTackle : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    WallCheck wallcheck;
    public bool isTackle = false;
    int keyCount = 0;
    public float speed;
    public float AddSpeed;
    public float MaxSpeed;
    float SetSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wallcheck = GameObject.Find("WallCheck").GetComponent<WallCheck>();
        SetSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            keyCount += 1;
            if (keyCount == 1)
            {
                isTackle = true;
            }
            if (keyCount == 2)
            {
                isTackle = false;
                speed = SetSpeed;
                keyCount = 0;
            }
            
        }

        if (isTackle)
        {
            if (wallcheck.touchWall == true)
            {
                rb.velocity = Vector3.zero;
                isTackle = false;
            }
            else
            {
                speed += AddSpeed;
                speed = Mathf.Clamp(speed, 0, MaxSpeed);
                rb.velocity = Vector3.zero;
                rb.velocity = transform.forward * speed;
            }
        }
    }
}
