using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiSize_Anim : MonoBehaviour
{
    private Animator Moti_main;
    //public MotiHuge HUGE;
    private string motiStr = "IsMotiSize";
    bool MotiSizeAnim = false;
    private Collider motiCollider1;
    private Collider motiCollider2;
    private Collider motiCollider3;
    private Collider motiCollider4;
    private Collider motiCollider5;
    private Collider motiCollider6;
    // Start is called before the first frame update
    void Start()
    {
        this.Moti_main = GetComponent<Animator>();
        this.Moti_main.SetBool(motiStr, false);
        motiCollider1 = GameObject.Find("mochi1").GetComponent<BoxCollider>();
        motiCollider2 = GameObject.Find("mochi2").GetComponent<BoxCollider>();
        motiCollider3 = GameObject.Find("mochi3").GetComponent<BoxCollider>();
        motiCollider4 = GameObject.Find("mochi4").GetComponent<BoxCollider>();
        motiCollider5 = GameObject.Find("mochi5").GetComponent<BoxCollider>();
        motiCollider6 = GameObject.Find("mochi6").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
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
    void FixedUpdate()
    {
        if (MotiSizeAnim)
        {
            this.Moti_main.SetBool(motiStr, true);
        }
        else
        {
            if (MotiSizeAnim == false)
            {
                this.Moti_main.SetBool(motiStr, false);
                //HUGE.ResetE();
            }
        }
    }
    void EnableAttack()
    {
        motiCollider1.enabled = true;
        motiCollider2.enabled = true;
        motiCollider3.enabled = true;
        motiCollider4.enabled = true;
        motiCollider5.enabled = true;
        motiCollider6.enabled = true;
    }
    void DisableAttack()
    {
        motiCollider1.enabled = false;
        motiCollider2.enabled = false;
        motiCollider3.enabled = false;
        motiCollider4.enabled = false;
        motiCollider5.enabled = false;
        motiCollider6.enabled = false;
    }
}
