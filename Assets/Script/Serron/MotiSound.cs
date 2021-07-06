using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiSound : MonoBehaviour
{

    private CriAtomSource Moti;
    // Start is called before the first frame update
    void Start()
    {
        Moti = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MotiSoundOn()
    {
        Moti.Play();
    }
}
