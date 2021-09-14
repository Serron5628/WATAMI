using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, Random.Range(-180.0f, 180.0f), 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
