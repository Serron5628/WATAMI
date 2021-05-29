using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiHuriorosi : MonoBehaviour
{
    private Animator Moti;
    public MotiHuge HUGE;
    private string motiStr = "isMoti";
    bool MotiAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        this.Moti = GetComponent<Animator>();
        this.Moti.SetBool(motiStr, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            MotiAnimation = true;
        }
        else
        {
            if(Input.GetMouseButton(0))
            {
                MotiAnimation = false;
            }
        }
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
