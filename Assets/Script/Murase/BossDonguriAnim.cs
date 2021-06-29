using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDonguriAnim : MonoBehaviour
{
    public GameObject RstampObj;
    public GameObject LstampObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
