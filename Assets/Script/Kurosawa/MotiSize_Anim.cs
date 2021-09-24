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

    void OnFire(InputValue input)
    {
        bool pressed = input.isPressed;
        if (!pressed)
        {
            this.Moti_main.SetBool(motiStr, true);
            this.Moti_main.SetBool(motiStr, false);
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

        KesuFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (KesuFlag)
        {
            count += Time.deltaTime;
            if (count > 1.0f)
            {
                KesuFlag = false;
                count = 0.0f;
                this.gameObject.SetActive(false);
            }
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
