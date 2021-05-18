using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGround = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("hit!");

        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("exit");

        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
