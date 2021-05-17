using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE3 : MonoBehaviour
{
    public GameObject Player;
    public StickE2 stickE2;
    private FixedJoint fixedJoint;
    bool Fixed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fixed = stickE2.fixedOn;
        if(Fixed==true)
        {
            gameObject.AddComponent<FixedJoint>();
            fixedJoint = GetComponent<FixedJoint>();
            fixedJoint.connectedBody = Player.gameObject.GetComponent<Rigidbody>();
        }
    }
}
