﻿using System.Collections;
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
    int groundcheckCount1 = 0;
    int groundcheckCount2 = 0;
    int groundcheckCount3 = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GameObject.Find("GroundChecker").GetComponent<GroundCheck>();
        parachute = GetComponent<PlayerParachute>();
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    void FixedUpdate()
    {
        if (playerState != fallState && playerState != jumpState
            && parachute.useParachute == false)
        {
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
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
            rb.velocity = moveForward * parachute.moveSpeed + new Vector3(0, rb.velocity.y, 0);

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
            if (setFallVelocity == false)
            {
                fallVelocity = new Vector3(rb.velocity.x * fallkansei, 0.0f, rb.velocity.z * fallkansei);

                setFallVelocity = true;
            }

            rb.velocity = new Vector3(fallVelocity.x, rb.velocity.y, fallVelocity.z);
        }
    }

    void Update()
    {
        if (playerState != jumpState)
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
        }
        if (playerState != fallState)
        {
            setFallVelocity = false;
        }

        if (playerState == jumpState && groundCheck.isGround == false)
        {
            startJumpflag = 0;
        }

        if (groundCheck.isGround == true)
        {
            if (startJumpflag == 1)
            {

            }
            else
            {
                playerState = groundState;
                isJumping = false;
                groundcheckCount1 = 0;
                groundcheckCount2 = 0;
                groundcheckCount3 = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerState == groundState)
        {
            startJumpflag = 1;
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

        if (rb.velocity.y < -0.1 && playerState != jumpState)
        {
            if (parachute.useParachute == true)
            {

            }
            else
            {
                playerState = fallState;
            }
        }

        //Unityで接地判定がとれなかったときの保険
        if (playerState == fallState && Mathf.Abs(rb.velocity.y) <= 0.1)
        {
            groundcheckCount1 += 1;
            if (groundcheckCount1 >= 5)
            {
                playerState = groundState;
                groundcheckCount1 = 0;
            }
        }
        if (playerState == jumpState && Mathf.Abs(rb.velocity.y) <= 0.1)
        {
            groundcheckCount2 += 1;
            if (groundcheckCount2 >= 5)
            {
                playerState = groundState;
                groundcheckCount2 = 0;
            }
        }
        if (playerState == parachute.parachuteDOWNState && Mathf.Abs(rb.velocity.y) <= 0.1)
        {
            groundcheckCount3 += 1;
            if (groundcheckCount3 >= 5)
            {
                playerState = groundState;
                groundcheckCount3 = 0;
            }
        }
    }
}
