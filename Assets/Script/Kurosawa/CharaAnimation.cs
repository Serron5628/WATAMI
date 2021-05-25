using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnimation : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isCharaAnim";
    bool CharaAnim = false;
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
            CharaAnim = true;
        }
        else
        {
            if(Input.GetMouseButton(0))
            {
                CharaAnim = false;
            }
        }
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
