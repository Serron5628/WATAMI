using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PDamage : MonoBehaviour
{
    public Slider slider;
    private void OnCollisionEnter(Collision collision)
    {

    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "enemy") 
            slider.GetComponent<DamageValue>().Attack_1();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy") 
            slider.GetComponent<DamageValue>().Attack_1();
        else if(other.gameObject.tag=="Boss")
            slider.GetComponent<DamageValue>().Attack_2();
    }
}
