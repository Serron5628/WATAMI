using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Time : MonoBehaviour
{
    [SerializeField]
    float timescale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timescale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
