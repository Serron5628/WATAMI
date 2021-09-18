using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiHuriorosi : MonoBehaviour
{
    private Animator Moti;
    public MotiHuge HUGE;
    private string motiStr = "isMoti";
    bool MotiAnimation = false;

    void OnFire(InputValue input)
    {
        var mousePressed = input.isPressed;
        MotiAnimation = !mousePressed;
    }
        
    // Start is called before the first frame update
    void Start()
    {
        this.Moti = GetComponent<Animator>();
        this.Moti.SetBool(motiStr, false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if(MotiAnimation)
        {
            this.Moti.SetBool(motiStr, true);
        }
        else
        {
            if(MotiAnimation==false)
            {
                this.Moti.SetBool(motiStr, false);
            }
        }
    }
}
