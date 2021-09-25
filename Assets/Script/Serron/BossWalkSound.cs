using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkSound : MonoBehaviour
{
    public GameObject StampSound;
    private CriAtomSource WalkBoss;
    private CriAtomSource stampsound;
    // Start is called before the first frame update
    void Start()
    {
        stampsound = StampSound.GetComponent<CriAtomSource>();
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

    void BossStampSound()
    {
        stampsound.Play();
    }
}
