﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiSize_Anim : MonoBehaviour
{
    private Animator Moti_main;
    //public MotiHuge HUGE;
    private string motiStr = "IsMotiSize";
    bool MotiSizeAnim = false;

    void OnFire(InputValue input)
    {
        var mousePressed = input.isPressed;
        MotiSizeAnim = !mousePressed;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Moti_main = GetComponent<Animator>();
        this.Moti_main.SetBool(motiStr, false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (MotiSizeAnim)
        {
            this.Moti_main.SetBool(motiStr, true);
        }
        else
        {
            if (MotiSizeAnim == false)
            {
                this.Moti_main.SetBool(motiStr, false);
                //HUGE.ResetE();
            }
        }
    }
}
