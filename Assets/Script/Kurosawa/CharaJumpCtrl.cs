using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaJumpCtrl : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isHissatu";
    bool HissatuAnim = false;

    void OnFire(InputValue input)
    {
        var mousePressed = input.isPressed;

        HissatuAnim = !mousePressed;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.usagi = GetComponent<Animator>();
        this.usagi.SetBool(usagiStr, false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (HissatuAnim)
        {
            this.usagi.SetBool(usagiStr, true);
        }
        else
        {
            if (HissatuAnim == false)
            {
                this.usagi.SetBool(usagiStr, false);
            }
        }
    }
}
