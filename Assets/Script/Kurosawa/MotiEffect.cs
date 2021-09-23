using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiEffect : MonoBehaviour
{
    [SerializeField] GameObject MotiTrailEffect;
    [SerializeField] GameObject MotiHurioroshiEffect;
    bool charge = false;
    public float countup = 0.0f;
    public float ActiveTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        MotiTrailEffect.SetActive(false);
        MotiHurioroshiEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (charge)
        {
            countup += Time.deltaTime;
            //Debug.Log(countup);
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
        MotiHurioroshiEffect.SetActive(false);
        countup = 0.0f;
    }
    public void HurioroshiActive()
    {
        if (countup >= ActiveTime)
        {
            MotiHurioroshiEffect.SetActive(true);
        }
    }
}
