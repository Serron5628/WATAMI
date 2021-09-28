using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDonguriAnim : MonoBehaviour
{
    public GameObject RstampObj;
    public GameObject LstampObj;

    public PlayerHp playerHp;

    public GameObject bossLeftFoot;
    public GameObject bossRightFoot;
    public GameObject playerObj;

    public bool isLeftFoot = false;
    public bool isRightFoot = false;

    private bool stumpFlag = false;

    void Start(){
        if(!playerObj)
            playerObj = GameObject.FindWithTag("Player");
    }

    void Update() {
        var playerPos = playerObj.transform.position;
        var bossLeftFootPos = bossLeftFoot.transform.position;
        var bossRightFootPos = bossRightFoot.transform.position;

        var distL = Vector3.Distance(
            new Vector3(playerPos.x, 0, playerPos.z), 
            new Vector3(bossLeftFootPos.x, 0, bossLeftFootPos.z));

        var distR = Vector3.Distance(
            new Vector3(playerPos.x, 0, playerPos.z), 
            new Vector3(bossRightFootPos.x, 0, bossRightFootPos.z));
        
        if(distL < 4.7f || distR < 4.7f)
            stumpFlag = true;
        else
            stumpFlag = false;
    }

    // Start is called before the first frame update
    void RightFoot(){
        if(stumpFlag)
            playerHp.Damage_RightStump();

        RstampObj.SetActive(true);
        isRightFoot = true;
    }

    void DRightFoot(){
        RstampObj.SetActive(false);
        isRightFoot = false;
    }

    void LeftFoot(){
        if(stumpFlag)
            playerHp.Damage_LeftStump();

        LstampObj.SetActive(true);
        isLeftFoot = true;
    }

    void DLeftFoot(){
        LstampObj.SetActive(false);
        isLeftFoot = false;
    }
}
