using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiSize_Anim : MonoBehaviour
{
    private Animator Moti_main;
    private string motiStr = "IsMotiSize";

    void OnFire(InputValue input)
    {
        bool pressed = input.isPressed;
        if (!pressed)
        {
            this.Moti_main.SetBool(motiStr, true);
        }
        else
        {
            this.Moti_main.SetBool(motiStr, false);
        }
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
    }
}
