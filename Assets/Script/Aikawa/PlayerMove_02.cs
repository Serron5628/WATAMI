using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_02 : MonoBehaviour
{
    Rigidbody rb;
    GroundCheck groundCheck;

    public static string playerState;
    string jumpState = "Jump";
    string groundState = "Ground";
    string fallState = "Fall";

    public float gravity;　　//（注）ゲーム全体の重力変更
    public float moveSpeed;
    public float jumpUPPower;
    public float jumpForwardPower;
    public float fallkansei;
    float inputHorizontal;
    float inputVertical;

    bool isJumping = false;
    bool setFallVelocity = false;
    Vector3 fallVelocity;
    int startJumpflag = 0;
    int jumpflag = 0;
    Vector3 moveForward,cameraForward;

    private CriAtomSource KoganeRun;  //サウンド関連

    void Start(){
        rb = GetComponent<Rigidbody>();
        groundCheck = GameObject.Find("GroundChecker").GetComponent<GroundCheck>();
        Physics.gravity = new Vector3(0, -gravity, 0);
        //CriAtomSourceの取得
        KoganeRun = GetComponent<CriAtomSource>();
    }
    public void PMove(){
        cameraForward = Vector3.Scale(
            Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        if (moveForward != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(moveForward);
    }

    void Update(){
        cameraForward = Vector3.Scale(
            Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        rb.velocity = moveForward + new Vector3(0, rb.velocity.y, 0);
        switch (playerState){
            case "Jump":
                if (groundCheck.isGround == false && rb.velocity.y < -0.1)
                    startJumpflag = 0;
                if(isJumping == false){
                    if (jumpflag == 1){
                        Vector3 v = transform.forward;
                        Vector3 vn = v.normalized;
                        rb.AddForce(vn.x * jumpForwardPower, jumpUPPower, vn.z * jumpForwardPower, ForceMode.Impulse);
                    }else if (jumpflag == 2)
                        rb.AddForce(0.0f, jumpUPPower, 0.0f, ForceMode.Impulse);
                    isJumping = true;
                }
                break;
            case "Ground":
                inputHorizontal = Input.GetAxisRaw("Horizontal");
                inputVertical = Input.GetAxisRaw("Vertical");
                if (Input.GetKeyDown(KeyCode.Space)){
                    startJumpflag = 1;
                    rb.velocity = Vector3.zero;
                }
                    //ジャンプ時における方向入力の有無
                if (inputHorizontal != 0 && inputVertical != 0){
                    playerState = jumpState;
                    jumpflag = 1;
                }else{
                    playerState = jumpState;
                    jumpflag = 2;
                }
                PMove();
                isJumping = false;
                break;
            case "Fall":
                if (setFallVelocity == false){
                    fallVelocity = new Vector3(rb.velocity.x * fallkansei, 0.0f, rb.velocity.z * fallkansei);
                    setFallVelocity = true;
                }
                rb.velocity = new Vector3(fallVelocity.x, rb.velocity.y, fallVelocity.z);
                break;
        }

        if (moveForward != Vector3.zero){
            transform.rotation = Quaternion.LookRotation(moveForward);
            //足音実装
            KoganeRun.Play();
        }
        if (playerState != fallState)
            setFallVelocity = false;

        if (groundCheck.isGround == true&&startJumpflag != 1)
            playerState = groundState;

        if (rb.velocity.y < -0.1 && playerState != jumpState)
            playerState = fallState;
    }
}
