using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donguri_FirstSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(GetComponent<SphereCollider>());
            Destroy(GetComponent<Rigidbody>());
            gameObject.GetComponent<EnemyMove>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            Destroy(this);

        }
    }
}
