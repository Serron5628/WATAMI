using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDonguriAnim : MonoBehaviour
{
    public GameObject RstampObj;
    public GameObject LstampObj;

    public bool isLeftFoot = false;
    public bool isRightFoot = false;
  
    // Start is called before the first frame update
    void RightFoot()
    {
        RstampObj.SetActive(true);
        isRightFoot = true;
    }
    void DRightFoot()
    {
        RstampObj.SetActive(false);
        isRightFoot = false;
    }

    void LeftFoot()
    {
        LstampObj.SetActive(true);
        isLeftFoot = true;
    }
    void DLeftFoot()
    {
        LstampObj.SetActive(false);
        isLeftFoot = false;
    }
}
