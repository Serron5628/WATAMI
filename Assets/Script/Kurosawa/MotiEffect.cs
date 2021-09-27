using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiEffect : MonoBehaviour
{
    [SerializeField] GameObject MotiTrailEffect;
    [SerializeField] GameObject MotiHurioroshiEffect;
    [SerializeField] GameObject MotiHitEffect;
    [SerializeField] GameObject MotiHurioroshiEffect_02;
    bool charge = false;
    public float countup = 0.0f;
    public float ActiveTime = 5.0f;
    // Start is called before the first frame update

    public GameObject kogane_wait;
    public EnemyDestroy_02 ED_02;
    int child;

    void Start()
    {
        MotiTrailEffect.SetActive(false);
        MotiHitEffect.SetActive(false);
        MotiHurioroshiEffect.SetActive(false);
        MotiHurioroshiEffect_02.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        charge = kogane_wait.GetComponent<CharaJumpCtrl_2>().CanBlend;
        child = ED_02.childNumber;
        if (charge)
        {
            countup += Time.deltaTime;
            //Debug.Log(countup);
        }
    }

    void OnFire(InputValue input)
    {
        var pressed = input.isPressed;
        MotiTrailEffect.SetActive(pressed);
    }
    public void EffectActive()
    {
        MotiTrailEffect.SetActive(true);
    }
    public void EffectDestroy()
    {
        MotiTrailEffect.SetActive(false);
        MotiHitEffect.SetActive(false);
        MotiHurioroshiEffect.SetActive(false);
        MotiHurioroshiEffect_02.SetActive(false);
        countup = 0.0f;
    }
    public void HurioroshiActive()
    {
        if(child >= 10)
        {
            MotiHitEffect.SetActive(true);
        }

        if(child >= 15)
        {
            MotiHurioroshiEffect.SetActive(true);
        }

        if(child >= 20)
        {
            MotiHurioroshiEffect_02.SetActive(true);
        }
    }
}
