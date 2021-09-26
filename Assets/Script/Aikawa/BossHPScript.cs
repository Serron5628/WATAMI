using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPScript : MonoBehaviour
{
    public Slider bossHpSlieder;
    public int maxHp = 100,nowHp;
    public EnemyDestroy_02 enemyDestroy_02;
    public int baseDamage = 2;

    public int Damage;
    int Donguri;
    int Burn;

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
    //ダメージ計算はこの下に。Donguriがくっついてるどんぐりの数で、Burnが燃えてるどんぐりの数
    public void Attack_DonguriLength()
    {
        Donguri = enemyDestroy_02.DonguriNumber;
        Burn = enemyDestroy_02.BurnDonguriNumber;


        Damage = enemyDestroy_02.DonguriNumber * 2 + enemyDestroy_02.BurnDonguriNumber * 4;
        bossHpSlieder.value -= Damage;
    }
}
