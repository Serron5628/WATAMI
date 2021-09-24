using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaJumpCtrl_2 : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isHissatu";

    public GameObject moti;
    private Animator Moti_spin;
    private string motiStr = "IsMotiSize";

    void OnFire(InputValue input)
    {
        bool pressed = input.isPressed;
        if (!pressed)
        {
            this.usagi.SetBool(usagiStr, true);
        }
        else
        {
            moti.SetActive(true);
            this.usagi.SetBool(usagiStr, false);
            Moti_spin.SetBool(motiStr, false);
        }
    }

    void Start(){
        usagi = GetComponent<Animator>();
        usagi.SetBool(usagiStr, false);

        Moti_spin = moti.GetComponent<Animator>();
        Moti_spin.SetBool(motiStr, false);
    }
    void Update()
    {

    }
}
