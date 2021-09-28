using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkSound : MonoBehaviour
{
    public GameObject StampSound;
    public GameObject BreathSound;
    public GameObject TackleSound;
    public GameObject TackleWalkSound;
    public GameObject DonguriVanish;

    private CriAtomSource WalkBoss;
    private CriAtomSource stampsound;
    private CriAtomSource breathsound;
    private CriAtomSource tacklesound;
    private CriAtomSource tacklewalksound;
    private CriAtomSource dongurivanish;

    // Start is called before the first frame update
    void Start()
    {
        WalkBoss = GetComponent<CriAtomSource>();
        stampsound = StampSound.GetComponent<CriAtomSource>();
        breathsound = BreathSound.GetComponent<CriAtomSource>();
        tacklesound = TackleSound.GetComponent<CriAtomSource>();
        tacklewalksound = TackleWalkSound.GetComponent<CriAtomSource>();
        dongurivanish = DonguriVanish.GetComponent<CriAtomSource>();
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
    void BossBreathSound()
    {
        breathsound.Play();
    }
    void BossTackleSound()
    {
        tacklesound.Play();
    }
    void BossTackleSoundStop()
    {
        tacklesound.Stop();
    }
    void BossTackleWalkSound()
    {
        tacklewalksound.Play();
    }
    void BossVanishSound()
    {
        dongurivanish.Play();
    }
}
