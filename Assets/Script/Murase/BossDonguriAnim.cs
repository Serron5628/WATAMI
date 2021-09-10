using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDonguriAnim : MonoBehaviour
{
    public GameObject BossDonguri;
    BossDonguriMove bossMove;
    public GameObject RstampObj;
    public GameObject LstampObj;
    public bool IsBreath = false;
    public bool stopBreath = false;
    public bool finishBreath = false;
    // Start is called before the first frame update
    void Start()
    {
        bossMove = BossDonguri.GetComponent<BossDonguriMove>();
    }

    void Update()
    {
        if (bossMove.selectAttack == 0)
        {
            IsBreath = false;
            stopBreath = false;
            finishBreath = false;
        }
    }
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
        IsBreath = true;
    }
    void StopBreath()
    {
        stopBreath = true;
    }

    void FinishBreath()
    {
        finishBreath = true;
    }
}
