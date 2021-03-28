using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    GroundCheck groundCheck;
    PlayerParachute parachute;

    public string playerState;
    string jumpState = "Jump";
    string groundState = "Ground";
    string fallState = "Fall";
  
    public float gravity;　　//（注）ゲーム全体の重力変更
    public float jumpUPPower;
    public float jumpForwardPower;
    float moveSpeed = 7.0f;
    float inputHorizontal;
    float inputVertical;

    bool isJumping = false;
    int jumpflag = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GameObject.Find("GroundChecker").GetComponent<GroundCheck>();
        parachute = GetComponent<PlayerParachute>();
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    void FixedUpdate()
    {
        if (playerState == groundState)
        {
            moveSpeed = 7.0f;

            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }
        }
        if (parachute.useParachute == true)
        {
            moveSpeed = 3.0f;
           
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;          
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }
        }

        if (playerState == jumpState)
        {
            if (isJumping == false)
            {
                if (jumpflag == 1)
                {
                    Vector3 v = transform.forward;
                    Vector3 vn = v.normalized;

                    rb.AddForce(vn.x * jumpForwardPower, jumpUPPower, vn.z * jumpForwardPower, ForceMode.Impulse);
                }
                if (jumpflag == 2)
                {
                    rb.AddForce(0.0f, jumpUPPower, 0.0f, ForceMode.Impulse);
                }
                isJumping = true;
            }
        }

        if (playerState == fallState)
        {
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }
    }

    void Update()
    {
        if (playerState != jumpState)
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
        }
       

        if (groundCheck.isGround == true && rb.velocity.y <= 0)
        {
            playerState = groundState;
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGround == true)
        {
            //ジャンプ時における方向入力の有無
            if (inputHorizontal != 0 || inputVertical != 0)
            {
                playerState = jumpState;
                rb.velocity = Vector3.zero;

                jumpflag = 1;
            }
            else
            {
                playerState = jumpState;
                rb.velocity = Vector3.zero;

                jumpflag = 2;
            }
        }

        if (rb.velocity.y < 0 && playerState != jumpState)
        {
            if (parachute.useParachute == true)
            {
                
            }
            else
            {
                playerState = fallState;
            }       
        }
    }
}
