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
        if (countup >= ActiveTime)
        {
            MotiHurioroshiEffect_01.SetActive(true);
            if (countup >= ActiveTime * 2)
            {
                MotiHurioroshiEffect_02.SetActive(true);
            }
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Boss")
    //    {
    //        Instantiate(MotiHurioroshiEffect_03, this.transform.position, Quaternion.identity);
    //    }
    //}
}
