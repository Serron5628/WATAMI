using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDonguriAnim : MonoBehaviour
{
    public GameObject RstampObj;
    public GameObject LstampObj;
    public bool IsBreath = false;
    public bool stopBreath = false;
    public bool finishBreath = false;
    // Start is called before the first frame update
    void RightFoot()
    {
        RstampObj.SetActive(true);
    }
    void DRightFoot()
    {
        RstampObj.SetActive(false);
    }

    void LeftFoot()
    {
        LstampObj.SetActive(true);
    }
    void DLeftFoot()
    {
        LstampObj.SetActive(false);
    }

    void startBreath()
    {
        finishBreath = false;
        stopBreath = false;
        IsBreath = true;
    }
    void StopBreath()
    {
        stopBreath = true;
        IsBreath = false;
    }

    void FinishBreath()
    {
        finishBreath = true;
    }
}
