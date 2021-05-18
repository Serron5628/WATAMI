using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE4 : MonoBehaviour
{
    public GameObject Player;
    Rigidbody rb;
    public bool rotationOn;
    // Start is called before the first frame update
    void Start()
    {
        rotationOn = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {       
        rb = gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.name == "Hako1")
        {
            other.gameObject.transform.parent = Player.gameObject.transform;
            rb.isKinematic = true;
            //transform.localPosition = new Vector3(0, 0, 0);
            rotationOn = false;
            //Debug.Log("hit");
        }
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("out");
        if (other.gameObject.name == "Hako1")
        {
            rotationOn = true;
            
        }
    }
}
