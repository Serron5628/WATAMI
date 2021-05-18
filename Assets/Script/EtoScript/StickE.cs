using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE : MonoBehaviour
{
    public GameObject moti;
    public GameObject ropeEnd;
    public float GOGO;
    private FixedJoint fixedJoint;
    Rigidbody rb;
    public bool flyOn;
    private bool parentOn;
    public bool ReParent;
    public Vector3 defaultScale = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        flyOn = false;
        parentOn = false;
        ReParent = true;
        defaultScale = transform.lossyScale;

    }
        
        // Update is called once per frame
    void FixedUpdate()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.Q))
        {
            if (parentOn == true)
            {
                rb.isKinematic = false;
                this.gameObject.transform.parent = ropeEnd.gameObject.transform;
                this.gameObject.transform.LookAt(ropeEnd.transform.position);
                rb.AddForce(transform.forward * GOGO, ForceMode.Impulse);
                flyOn = true;
                Debug.Log("tit");
                ReParent = false;
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if(fixedJoint==null&&ReParent==true&&other.gameObject.name=="MOTI")
        {
            this.gameObject.transform.parent=moti.gameObject.transform;
            //Vector3 scale = transform.localScale;
            //scale.x /= moti.localScale.x;
            //scale.y /= moti.localScale.y;
            //scale.z /= moti.localScale.z;
            //transform.localScale = scale;
            //this.gameObject.transform.SetParent(transform, false);
            rb.isKinematic = true;
            //transform.localPosition = new Vector3(0, 0, 0);
            parentOn = true;
            //Debug.Log("hit");
        }
        
    }
    
}
