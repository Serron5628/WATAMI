using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stay : MonoBehaviour
{
    [SerializeField]
    GameObject stObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = stObj.transform.position;
    }
}
