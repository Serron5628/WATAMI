using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE5 : MonoBehaviour
{
    public bool ReParent;

    public bool m0;
    public bool m1;
    public bool m2;
    public bool m3;
    public bool m4;
    public bool m5;
    public bool m6;

    public GameObject moti;
    public GameObject moti1;
    public GameObject moti2;
    public GameObject moti3;
    public GameObject moti4;
    public GameObject moti5;
    public GameObject moti6;
    public DeleteE deleteE;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        ReParent = deleteE.reParent;
        m0 = false;
        m1 = true;
        m2 = true;
        m3 = true;
        m4 = true;
        m5 = true;
        m6 = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider collision)
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.name == "mochi" && ReParent == true && m0==true)
        {
            this.gameObject.transform.parent = moti.gameObject.transform;
            rb.isKinematic = true;
            m1 = false;
            m2 = false;
            m3 = false;
            m4 = false;
            m5 = false;
            m6 = false;
        }
        if (collision.gameObject.name == "mochi1" && ReParent == true && m1 == true)
        {
            this.gameObject.transform.parent = moti1.gameObject.transform;
            rb.isKinematic = true;
            m0 = false;
            m2 = false;
            m3 = false;
            m4 = false;
            m5 = false;
            m6 = false;
        }
        if (collision.gameObject.name == "mochi2" && ReParent == true && m2 == true)
        {
            this.gameObject.transform.parent = moti2.gameObject.transform;
            rb.isKinematic = true;
            m1 = false;
            m0 = false;
            m3 = false;
            m4 = false;
            m5 = false;
            m6 = false;
        }
        if (collision.gameObject.name == "mochi3" && ReParent == true && m3 == true)
        {
            this.gameObject.transform.parent = moti3.gameObject.transform;
            rb.isKinematic = true;
            m1 = false;
            m2 = false;
            m0 = false;
            m4 = false;
            m5 = false;
            m6 = false;
        }
        if (collision.gameObject.name == "mochi4" && ReParent == true && m4 == true)
        {
            this.gameObject.transform.parent = moti4.gameObject.transform;
            rb.isKinematic = true;
            m1 = false;
            m2 = false;
            m3 = false;
            m0 = false;
            m5 = false;
            m6 = false;
        }
        if (collision.gameObject.name == "mochi5" && ReParent == true && m5 == true)
        {
            this.gameObject.transform.parent = moti5.gameObject.transform;
            rb.isKinematic = true;
            m1 = false;
            m2 = false;
            m3 = false;
            m4 = false;
            m0 = false;
            m6 = false;
        }
        if (collision.gameObject.name == "mochi6" && ReParent == true && m6 == true)
        {
            this.gameObject.transform.parent = moti6.gameObject.transform;
            rb.isKinematic = true;
            m1 = false;
            m2 = false;
            m3 = false;
            m4 = false;
            m5 = false;
            m0 = false;
        }
    }
}
