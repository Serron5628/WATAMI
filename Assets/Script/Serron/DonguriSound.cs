using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonguriSound : MonoBehaviour
{
    public GameObject RollingSound;
    private CriAtomSource rollingsound;
    // Start is called before the first frame update
    void Start()
    {
        rollingsound = RollingSound.GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DonguriRolling()
    {
        rollingsound.Play();
    }
}
