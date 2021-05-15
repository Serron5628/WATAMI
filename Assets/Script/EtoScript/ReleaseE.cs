using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseE : MonoBehaviour
{
    public StickE4 stickE4;
    Rigidbody rb;
    public bool rotational2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OntriggerEnter(Collider other)
    {
        rotational2 = stickE4.rotationOn;
        if (other.gameObject.name=="Hako1")
        {
            other.transform.parent = null;
            rb.isKinematic = false;
            rotational2 = true;
        }
    }
}
