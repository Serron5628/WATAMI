using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE : MonoBehaviour
{
    public GameObject moti;
    private FixedJoint fixedJoint;
    private float breakForce = 220f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(fixedJoint==null)
        {
            //this.gameObject.transform.parent = moti.gameObject.transform;
            gameObject.AddComponent<FixedJoint>();
            fixedJoint = GetComponent<FixedJoint>();
            fixedJoint.connectedBody = moti.gameObject.GetComponent<Rigidbody>();
            fixedJoint.breakForce = breakForce;
            fixedJoint.enableCollision = true;
            fixedJoint.enablePreprocessing = true;
            Debug.Log("hit");
        }
        
    }
}
