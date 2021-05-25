using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE5 : MonoBehaviour
{
    public bool ReParent;
    public GameObject moti;
    public DeleteE deleteE;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        ReParent = deleteE.reParent;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;

        rb = gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.name=="MOTI")
        {
            localAngle.x = 0;
            localAngle.y = 0;
            localAngle.z = 0;
            myTransform.localEulerAngles = localAngle;

            this.gameObject.transform.parent = moti.gameObject.transform;
            rb.isKinematic = true;
        }
    }
}
