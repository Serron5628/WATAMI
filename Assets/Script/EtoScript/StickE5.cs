using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE5 : MonoBehaviour
{
    public bool ReParent;
    public GameObject moti;
    public DeleteE deleteE;

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
        rb = gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.name == "mochi" && ReParent == true)
        {
            this.gameObject.transform.parent = moti.gameObject.transform;
        }
    }
}