﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_ZERO : MonoBehaviour
{
    /*
        <<HPがゼロになった時の遷移に使うとき>>
    
        1.playerのHPがゼロになったとき

            public HP_ZERO hp_zero;

                と宣言しておいて

            if(!hp_zero.playerHP_ZERO)
            {
            }

        2.bossのHPがゼロになったとき

            public HP_ZERO hp_zero;

                と宣言しておいて

            if(!hp_zero.bossHP_ZERO)
            {
            }
    */
    
    //
    public Slider playerHP;
    public Slider bossHP;

    public bool playerHP_ZERO = false;
    public bool bossHP_ZERO = false;

    void Update()
    {
        if(playerHP.value == 0)
        {
            playerHP_ZERO = true;
        }
        if(bossHP.value == 0)
        {
            bossHP_ZERO = true;
        }
    }
}