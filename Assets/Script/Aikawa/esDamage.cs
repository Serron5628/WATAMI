using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class esDamage : MonoBehaviour
{
    public Slider slider;
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            slider.GetComponent<DamageValue>().Attack_1();
        }
    }
}
