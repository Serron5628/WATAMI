using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huge : MonoBehaviour
{
    public float plus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hugeScale()
    {
        transform.localScale = new Vector3(2.0f+plus, 0.1f, 1);
        plus = plus + 0.1f;
    }
}
