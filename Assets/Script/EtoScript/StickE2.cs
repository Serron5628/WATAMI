using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE2 : MonoBehaviour
{
    public GameObject Player;
    private FixedJoint fixedJoint;
    public bool fixedOn;
    public Vector3 defaultScale = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        fixedOn = false;
        defaultScale = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lossScale = transform.lossyScale;
        Vector3 localScale = transform.localScale;
        transform.localScale = new Vector3(
            localScale.x / lossScale.x * defaultScale.x,
            localScale.y / lossScale.y * defaultScale.y,
            localScale.z / lossScale.z * defaultScale.z);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name=="MOTI")
        {
            gameObject.AddComponent<FixedJoint>();
            fixedJoint = GetComponent<FixedJoint>();
            fixedJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            fixedOn = true;
        }
    }
}
