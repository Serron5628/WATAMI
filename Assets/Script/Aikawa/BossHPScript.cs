using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPScript : MonoBehaviour
{
    public Slider bossHpSlieder;
    public int maxHp = 100,nowHp;
    public EnemyDestroy_02 enemyDestroy_02;
    void Start()
    {
        nowHp = maxHp;
        bossHpSlieder.maxValue = maxHp;
        bossHpSlieder.value = nowHp;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="lastAttack")
        {
            Attack_DonguriLength();
        }
    }
    public void Attack_1()
    {
        bossHpSlieder.value -= 10;
    }
    public void Attack_DonguriLength()
    {
        bossHpSlieder.value -= enemyDestroy_02.ChildObject.Length;
    }
}
