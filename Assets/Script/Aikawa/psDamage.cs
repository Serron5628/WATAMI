using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class psDamage : MonoBehaviour
{
    public Slider slider;
    GameObject enemy;
    private void FixedUpdate() {
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }
    public void OnCollisionExit(Collision collision)
    {
        if(enemy)
        {
        if (collision.gameObject.tag == "enemy") 
            slider.GetComponent<DamageValue>().Attack_1();
        }

    }
}
