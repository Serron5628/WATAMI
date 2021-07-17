using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiBend_Anim : MonoBehaviour
{
    private Animator animator;

    private string bendStr = "isBend";
    private string motiStr = "IsMotiSize";
    bool MotiSizeAnim = false;
    //float current_length = this.animator.GetFloat("Length");
    //public GameObject Player;
    //public MotiHuge HUGE;   
    // Start is called before the first frame update
    void Start()
    {
        //自身のAnimatorを習得する
        this.animator = GetComponent<Animator>();
        this.animator.SetBool(motiStr, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //action = true;
            //this.animator.SetBool(bendStr, true);
            float blend = this.animator.GetFloat("Blend");
            blend = blend+0.1f*Time.deltaTime;
            this.animator.SetFloat("Blend", blend);
        }
        else
        {
            //action = false;
            float blend = this.animator.GetFloat("Blend");
            blend = 0.0f;
            //blend = blend;
            this.animator.SetFloat("Blend", blend);

        }
        if (Input.GetMouseButtonUp(0))
        {
            MotiSizeAnim = true;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                MotiSizeAnim = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (MotiSizeAnim)
        {
            this.animator.SetBool(motiStr, true);
        }
        else
        {
            if (MotiSizeAnim == false)
            {
                this.animator.SetBool(motiStr, false);
                //HUGE.ResetE();
            }
        }
    }
}
