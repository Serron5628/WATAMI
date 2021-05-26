using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eSizeTest : MotiHuge
{
    public GameObject Moti;
    new Vector3 MotiS;
    new Vector3 enemyS;
    new Vector3 mVSe;

    bool flag;

    void Start()
    {
       MotiS = Moti.transform.localScale;
       mVSe = new Vector3
       (transform.localScale.x /MotiS.x, 
       transform.localScale.y / MotiS.y, 
       transform.localScale.z / MotiS.z);
    }

    void FixedUpdate()
    {
        if(!(this.gameObject.transform.parent==null))
        {
            transform.localScale = transform.localScale /plus;
        }
    }
}
