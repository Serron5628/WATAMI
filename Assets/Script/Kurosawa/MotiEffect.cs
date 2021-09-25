using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiEffect : MonoBehaviour
{
    [SerializeField] GameObject MotiTrailEffect;
    [SerializeField] GameObject MotiHurioroshiEffect_01;
    [SerializeField] GameObject MotiHurioroshiEffect_02;
    [SerializeField] GameObject MotiHurioroshiEffect_03;
    bool charge = false;
    public float countup = 0.0f;
    public float ActiveTime = 5.0f;
    public int EffectCount = 0;
    public HitControllBurn BurnEnemyHit;
    public HitControllTemp TempEnemyHit;
    // Start is called before the first frame update
    void Start()
    {
        MotiTrailEffect.SetActive(false);
        MotiHurioroshiEffect_01.SetActive(false);
        MotiHurioroshiEffect_02.SetActive(false);
        MotiHurioroshiEffect_03.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (charge)
        //{
        //    countup += Time.deltaTime;
        //    Debug.Log(countup);
        //}
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
        MotiTrailEffect.SetActive(pressed);
    }
    public void EffectActive()
    {
        MotiTrailEffect.SetActive(true);
    }
    public void EffectDestroy()
    {
        MotiTrailEffect.SetActive(false);
        MotiHurioroshiEffect_01.SetActive(false);
        MotiHurioroshiEffect_02.SetActive(false);
        MotiHurioroshiEffect_03.SetActive(false);
        countup = 0.0f;
    }
    public void HurioroshiActive()
    {
        MotiHurioroshiEffect_03.SetActive(true);
        MotiHurioroshiEffect_02.SetActive(true);
        MotiHurioroshiEffect_03.SetActive(true);
        if (EffectCount>=1)
        {
            MotiHurioroshiEffect_01.SetActive(true);
            Debug.Log("Zikkou");
            if (EffectCount>=5)
            {
                MotiHurioroshiEffect_02.SetActive(true);
            }
        }
        //if (countup >= ActiveTime)
        //{
        //    MotiHurioroshiEffect_01.SetActive(true);
        //    if (countup >= ActiveTime * 2)
        //    {
        //        MotiHurioroshiEffect_02.SetActive(true);
        //    }
        //}
        //if (EnemyHit.hitCount > 5)
        //{

        //}
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
