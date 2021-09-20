using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE5 : MonoBehaviour
{
    public bool ReParent;

    public bool[] m = new bool[7];

    public GameObject[] moti = new GameObject[7];

    //public bool m0;
    //public bool m1;
    //public bool m2;
    //public bool m3;
    //public bool m4;
    //public bool m5;
    //public bool m6;

    //public GameObject moti;
    //public GameObject moti1;
    //public GameObject moti2;
    //public GameObject moti3;
    //public GameObject moti4;
    //public GameObject moti5;
    //public GameObject moti6;

    public DeleteE deleteE;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        ReParent = deleteE.reParent;
        for(int i=1;i<7;i++)
        {
            m[i] = true;
        }
        m[0] = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider collision)
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.name == "mochi" && m[0] == true)
        {
            this.gameObject.transform.parent = moti[0].gameObject.transform;
            rb.isKinematic = true;
            m[1] = false;
            m[2] = false;
            m[3] = false;
            m[4] = false;
            m[5] = false;
            m[6] = false;
        }
        if (collision.gameObject.name == "mochi1" && m[1] == true)
        {
            this.gameObject.transform.parent = moti[1].gameObject.transform;
            rb.isKinematic = true;
            m[0] = false;
            m[2] = false;
            m[3] = false;
            m[4] = false;
            m[5] = false;
            m[6] = false;
        }
        if (collision.gameObject.name == "mochi2" && m[2] == true)
        {
            this.gameObject.transform.parent = moti[2].gameObject.transform;
            rb.isKinematic = true;
            m[1] = false;
            m[0] = false;
            m[3] = false;
            m[4] = false;
            m[5] = false;
            m[6] = false;
        }
        if (collision.gameObject.name == "mochi3" && m[3] == true)
        {
            this.gameObject.transform.parent = moti[3].gameObject.transform;
            rb.isKinematic = true;
            m[1] = false;
            m[2] = false;
            m[0] = false;
            m[4] = false;
            m[5] = false;
            m[6] = false;
        }
        if (collision.gameObject.name == "mochi4" && m[4] == true)
        {
            this.gameObject.transform.parent = moti[4].gameObject.transform;
            rb.isKinematic = true;
            m[1] = false;
            m[2] = false;
            m[3] = false;
            m[0] = false;
            m[5] = false;
            m[6] = false;
        }
        if (collision.gameObject.name == "mochi5" && m[5] == true)
        {
            this.gameObject.transform.parent = moti[5].gameObject.transform;
            rb.isKinematic = true;
            m[1] = false;
            m[2] = false;
            m[3] = false;
            m[4] = false;
            m[0] = false;
            m[6] = false;
        }
        if (collision.gameObject.name == "mochi6" && m[6] == true)
        {
            Debug.Log("hit");
            this.gameObject.transform.parent = moti[6].gameObject.transform;
            rb.isKinematic = true;
            m[1] = false;
            m[2] = false;
            m[3] = false;
            m[4] = false;
            m[5] = false;
            m[0] = false;
        }
    }
}