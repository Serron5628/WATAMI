using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiSize_Anim : MonoBehaviour
{
    private Animator Moti_main;
    private string motiStr = "IsMotiSize";
    private string waitStr = "IsWait";

    bool KesuFlag;
    float count = 0.0f;

    bool Tatakituke;

    public GameObject kogane_wait;

    void OnFire(InputValue input)
    {
        bool pressed = input.isPressed;
        if (!pressed)
        {
            //this.Moti_main.SetBool(motiStr, true);
        }
        else
        {
            //this.Moti_main.SetBool(motiStr, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Moti_main = GetComponent<Animator>();
        this.Moti_main.SetBool(motiStr, false);

        KesuFlag = false;
        Tatakituke = false;
    }

    // Update is called once per frame
    void Update()
    {
        Tatakituke = kogane_wait.GetComponent<CharaJumpCtrl_2>().Tatakituke;
        if (KesuFlag)
        {
            count += Time.deltaTime;
            if (count > 0.1f)
            {
                KesuFlag = false;
                count = 0.0f;
                this.gameObject.SetActive(false);
            }
        }

        if (Tatakituke)
        {
            this.Moti_main.SetBool(motiStr, true);
        }
        else
        {
            this.Moti_main.SetBool(motiStr, false);
        }
    }
    public void ActiveFalse()
    {
        KesuFlag = true;
    }

    public void DontTatakituke()
    {
        this.Moti_main.SetBool(motiStr, false);
    }
}
