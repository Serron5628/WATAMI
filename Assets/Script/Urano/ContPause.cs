using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f && gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
        }
    }
}
