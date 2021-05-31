using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaJumpCtrl : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isHissatu";
    bool HissatuAnim = false;
    // Start is called before the first frame update
    void Start()
    {
        this.usagi = GetComponent<Animator>();
        this.usagi.SetBool(usagiStr, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            HissatuAnim = true;
        }
        else
        {
            if(Input.GetMouseButton(0))
            {
                HissatuAnim = false;
            }
        }
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
