using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSound : MonoBehaviour
{
    private CriAtomSource Run;
    // Start is called before the first frame update
    void Start()
    {
        Run = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RunFlag()
    {
        Run.Play();
    }

}
