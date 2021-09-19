using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaAnimation : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isCharaAnim";
    bool CharaAnim = false;

    void OnFire(InputValue input)
    {
        var mousePressed = input.isPressed;

        CharaAnim = !mousePressed;
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
    private void FixedUpdate()
    {
        if(CharaAnim)
        {
            this.usagi.SetBool(usagiStr, true);
        }
        else
        {
            if(CharaAnim==false)
            {
                this.usagi.SetBool(usagiStr, false);
            }
        }
    }
}
