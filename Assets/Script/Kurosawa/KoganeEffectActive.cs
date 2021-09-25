using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoganeEffectActive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TrailEffect;
    void Start()
    {
        //TrailEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotateActive()
    {
        TrailEffect.SetActive(true);
    }
}
