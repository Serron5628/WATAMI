﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoganeAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    private string rotateStr = "isRotate";
    private string walkStr = "isWalk";
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            //wait next Rotation
            this.animator.SetBool(rotateStr, true);
        }
        else
        {
            //wait
            this.animator.SetBool(rotateStr, false);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            this.animator.SetBool(walkStr, true);
        }
        else
        {
            this.animator.SetBool(walkStr, false);
        }
    }
}
