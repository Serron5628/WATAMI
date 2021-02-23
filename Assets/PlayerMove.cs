using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public string playerState;
    public string nullStr = "isnull";
    string jumpStr = "isJamp";
    public string parachuteUP = "isPup";
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerState = nullStr;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0.0f, 0.0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0.0f, 0.0f, -0.1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0 && playerState != parachuteUP)
        {
            rb.AddForce(0.0f, 8.0f, 0.0f, ForceMode.Impulse);
            playerState = jumpStr;
        }

        //Debug.Log(playerState);
    }
}
