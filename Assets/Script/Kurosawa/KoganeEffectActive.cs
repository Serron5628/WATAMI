using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KoganeEffectActive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TrailEffect;
    public GameObject SyogekiEffect_01;
    public GameObject SyogekiEffect_02;
    public GameObject SyogekiEffect_03;

    public int EffectCount = 0;
    public float countup = 0.0f;
    public float ActiveTime = 5.0f;
    bool charge = false;
    public HitControllBurn BurnEnemyHit;
    public HitControllTemp TempEnemyHit;
    void Start()
    {
        TrailEffect.SetActive(false);
        SyogekiEffect_01.SetActive(false);
        SyogekiEffect_02.SetActive(false);
        SyogekiEffect_03.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (charge)
        {
            countup += Time.deltaTime;
            Debug.Log(countup);
        }
    }

    void OnFire(InputValue input)
    {
        var pressed = input.isPressed;
        charge = pressed;
        //TrailEffect.SetActive(pressed);
    }
    public void RotateActive()
    {
        TrailEffect.SetActive(true);
    }
    public void TatakitukeActive()
    {
        SyogekiEffect_01.SetActive(true);
        if (countup >= 5)
        {
            SyogekiEffect_02.SetActive(true);
            Debug.Log("Zikkou");
            if (countup >= 10)
            {
                SyogekiEffect_03.SetActive(true);
            }
        }
    }
    public void EffectDestroy()
    {
        TrailEffect.SetActive(false);
        SyogekiEffect_01.SetActive(false);
        SyogekiEffect_02.SetActive(false);
        SyogekiEffect_03.SetActive(false);
        countup = 0.0f;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            EffectCount++;
            Debug.Log("EffectCount");
        }
    }
}
