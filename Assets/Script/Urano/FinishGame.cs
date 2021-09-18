﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    bool end;
    public HP_ZERO hp_zero;
    public GameObject kogane;   //kogane_wait
    public GameObject koganeMat;
    public Material gameOverMat;
    public GameObject boss; //Donguri Hannya2

    // Start is called before the first frame update
    void Start()
    {
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (end == false)
        {
            if (hp_zero.playerHP_ZERO)
            {
                kogane.GetComponent<Animator>().SetTrigger("gameover");
                koganeMat.GetComponent<Renderer>().material = gameOverMat;
                end = true;
            }
            else if (hp_zero.bossHP_ZERO)
            {
                boss.GetComponent<Animator>().SetTrigger("down");
                end = true;
            }
        }
    }
}