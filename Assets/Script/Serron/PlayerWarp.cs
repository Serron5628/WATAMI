using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    public GameObject Warp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Fixedupdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Warp")
        {
            this.gameObject.transform.position = new Vector3(0f,2.5f,8.5f);
            Destroy(Warp.gameObject);
        }
    }
}
