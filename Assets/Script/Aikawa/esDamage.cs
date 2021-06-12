using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class esDamage : MonoBehaviour{
    public Slider slider;
    public void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "lastAttack")slider.GetComponent<DamageValue>().Attack_3();
        if (other.gameObject.tag == "Moti")slider.GetComponent<DamageValue>().Attack_1();
    }
}
