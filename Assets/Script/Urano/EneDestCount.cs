using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneDestCount : MonoBehaviour
{
    public int count;
    [SerializeField]
    GameObject appear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            appear.SetActive(true); 
            Destroy(this.gameObject);
        }
        //Debug.Log(count);
    }
}