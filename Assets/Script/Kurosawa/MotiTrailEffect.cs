using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiTrailEffect : MonoBehaviour
{
    [SerializeField] GameObject TrailEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        TrailEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    TrailEffect.SetActive(true);
        //}
        //else
        //{
        //    TrailEffect.SetActive(false);
        //}
    }
    void OnFire(InputValue input)
    {
        var pressed = input.isPressed;
        TrailEffect.SetActive(true);
        if (!pressed)
        {
            TrailEffect.SetActive(false);
        }
    }
    public void EffectStart()
    {
        TrailEffect.SetActive(true);
    }
    public void EffectDestroy()
    {
        TrailEffect.SetActive(false);
    }
}
