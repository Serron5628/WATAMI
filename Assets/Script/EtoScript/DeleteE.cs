using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteE : MonoBehaviour
{
    float seconds;
    public bool deleteOn;
    public bool reParent;
    // Start is called before the first frame update
    void Start()
    {
        deleteOn = false;
        reParent = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (deleteOn == true)
        {
            seconds += Time.deltaTime;
            Debug.Log("OK");
            if (seconds >= 5.0)
            {
                Destroy(this.gameObject);
                Debug.Log("ALL OK");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "ReleasePoint")
        {
            deleteOn = true;
            reParent = false;
        }
    }
}
