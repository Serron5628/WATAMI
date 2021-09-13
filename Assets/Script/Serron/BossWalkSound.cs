using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkSound : MonoBehaviour
{
    private CriAtomSource WalkBoss;
    // Start is called before the first frame update
    void Start()
    {
        WalkBoss = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BossSoundWalk()
    {
        WalkBoss.Play();
    }
}
