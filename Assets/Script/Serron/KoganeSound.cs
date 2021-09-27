using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoganeSound : MonoBehaviour
{
    public GameObject R;
    private CriAtomSource RAshioto;
    public GameObject L;
    private CriAtomSource LAshioto;
    public GameObject DownSound;
    private CriAtomSource downsound;
    // Start is called before the first frame update
    void Start()
    {
        RAshioto = R.GetComponent<CriAtomSource>();
        LAshioto = L.GetComponent<CriAtomSource>();
        downsound = DownSound.GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RRunFlag()
    {
        RAshioto.Play();
    }
    void LRunFlag()
    {
        LAshioto.Play();
    }
    void KoganeDownSound()
    {
        downsound.Play();
    }
}
