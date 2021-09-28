using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StickE5 : MonoBehaviour
{
    public bool ReParent;


    bool SmashOn;

    public bool[] m = new bool[7];

    public GameObject[] moti = new GameObject[7];

    public DeleteE deleteE;

    MotiBend_Anim MBA;

    public GameObject kogane_wait;
    CharaJumpCtrl_2 CJC_2;
    public bool CanBlend;

    // Start is called before the first frame update
    void Start()
    {
        ReParent = deleteE.reParent;
        
        for (int i = 1; i < m.Length; i++)
        {
            m[i] = true;
        }
        m[0] = false;

        CanBlend = kogane_wait.GetComponent<CharaJumpCtrl_2>().CanBlend;
    }

    // Update is called once per frame
    void Update()
    {
        CanBlend = kogane_wait.GetComponent<CharaJumpCtrl_2>().CanBlend;
    }

    void OnTriggerStay(Collider collision)
    {
        CanBlend = kogane_wait.GetComponent<CharaJumpCtrl_2>().CanBlend;
        for (int i = 0; i < moti.Length; ++i)
        {
            var objName = "mochi";
            if (i > 0) objName = $"mochi{i}";

            if (collision.gameObject.name == objName && m[i])
            {
                if(CanBlend == true)
                {
                    this.gameObject.transform.parent = moti[i].gameObject.transform;

                    // このインデックス以外のmのboolをfalseに設定
                    for (int j = 0; j < moti.Length; ++j)
                    {
                        if (j != i) m[j] = false;
                    }
                }
                
            }
        }
    }
}