using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class psDamage : MonoBehaviour
{
    public Slider slider;
    private void OnCollisionEnter(Collision collision)
    {

    }
    public void OnCollisionExit(Collision collision)
    {
        slider.GetComponent<DamageValue>().Attack_1();
    }
}
