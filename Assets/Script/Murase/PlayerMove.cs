using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    GroundCheck groundCheck;

    public string playerState;
    string jumpState = "Jump";
    public string groundState = "Ground";
    public string fallState = "Fall";
    string parachuteUPState = "Pup";
    string parachuteDOWNState = "Pdown";

    public float gravity;　　//（注）ゲーム全体の重力変更
    public float moveSpeed;
    public float RmoveSpeed;//餅回転中の歩行速度
    public float jumpUPPower;
    public float jumpForwardPower;
    public float fallkansei;
    float inputHorizontal;
    float inputVertical;

    bool isJumping = false;
    bool setFallVelocity = false;
    bool pushmouse;
    Vector3 fallVelocity;
    int startJumpflag = 0;
    int jumpflag = 0;
    int groundcheckCount1 = 0;
    int groundcheckCount2 = 0;
    int groundcheckCount3 = 0;

    Vector3 pos;
    Vector3 updraftPos;
    Vector3 updraftScl;
    public float PmoveSpeed;
    public float PminFallSpeed;
    public float PriseSpeed;
    public bool useParachute = false;
    public bool inUpdraft = false;
    bool reachEndPos = false;
    int tmp = 0;

    void OnFire(InputValue input)
    {
        pushmouse = input.isPressed;
    }
    void OnMove(InputValue input)
    {
        var inputVec = input.Get<Vector2>();
        inputHorizontal = inputVec.x;
        inputVertical = inputVec.y;
    }
    void OnParachute(InputValue input)
    {
        useParachute = input.isPressed;
    }
    void OnJump(InputValue input)
    {
        var pressed = input.isPressed;
        if (pressed && playerState == groundState)
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
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GameObject.Find("GroundChecker").GetComponent<GroundCheck>();
        Physics.gravity = new Vector3(0, -gravity, 0);

    }

    void FixedUpdate()
    {
        if (playerState == groundState)
        {
            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
            
            
            if (moveForward != Vector3.zero)
            {
                if (pushmouse)
                {
                    rb.velocity = moveForward * RmoveSpeed + new Vector3(0, rb.velocity.y, 0);
                }
                else
                {
                    // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
                    rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
                    // キャラクターの向きを進行方向に
                    transform.rotation = Quaternion.LookRotation(moveForward);
                }
            }
        }
        if (useParachute == true)
        {
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
            rb.velocity = moveForward * PmoveSpeed + new Vector3(0, rb.velocity.y, 0);

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

        //下降時　終端速度(minFallSpeed)
        if (useParachute == true && inUpdraft == false)
        {
            if (rb.velocity.y < -0.1)
            {
                playerState = parachuteDOWNState;
                rb.mass = 1;
                rb.drag = 2;
                rb.useGravity = false;
                var target_velocity = new Vector3(0f, -PminFallSpeed, 0f);
                rb.AddForce(target_velocity * rb.mass * rb.drag / (1f - rb.drag * Time.fixedDeltaTime));
                //Debug.Log(rb.velocity.magnitude);
            }
            else
            {
                rb.useGravity = true;
            }
        }
        //上昇時
        if (useParachute == true && inUpdraft == true)
        {
            playerState = parachuteUPState;
            pos = transform.position;
            float nextPosY = pos.y + PriseSpeed;
            float updraftEnd = updraftPos.y + (updraftScl.y / 2);

            rb.drag = 0;
            rb.useGravity = false;

            if (tmp == 0)
            {
                rb.velocity = Vector3.zero;
                tmp = 1;
            }

            if (pos.y >= updraftEnd)
            {
                reachEndPos = true;
            }
            else
            {
                reachEndPos = false;
            }

            if (reachEndPos == false)
            {
                //次の座標が上昇気流範囲を越える場合の補正
                if (nextPosY > updraftEnd)
                {
                    float tmpSpeed = updraftEnd - pos.y;
                    transform.Translate(0.0f, tmpSpeed, 0.0f);
                    reachEndPos = true;
                }
                else
                {
                    transform.Translate(0.0f, PriseSpeed, 0.0f);
                }
            }
        }
    }

    void Update()
    {
        if (playerState != fallState)
        {
            setFallVelocity = false;
        }

        if (!useParachute)
        {
            rb.drag = 0;
            rb.useGravity = true;
            tmp = 0;
        }

        if (groundCheck.isGround == true)
        {
            if (startJumpflag == 1)
            {

            }
            else
            {
                playerState = groundState;
            }
        }

        if (playerState == jumpState && groundCheck.isGround == false && rb.velocity.y < -0.1)
        {
            startJumpflag = 0;
        }


        if (playerState == groundState)
        {
            isJumping = false;
            groundcheckCount1 = 0;
            groundcheckCount2 = 0;
            groundcheckCount3 = 0;
        }

        if (rb.velocity.y < -0.1 && playerState != jumpState)
        {
            if (useParachute == true)
            {

            }
            else
            {
                playerState = fallState;
            }
        }

        //Unityで接地判定がとれなかったときの保険
        if (playerState == fallState && Mathf.Abs(rb.velocity.y) <= 0.00001)
        {
            groundcheckCount1 += 1;
            if (groundcheckCount1 >= 20)
            {
                playerState = groundState;
                groundcheckCount1 = 0;
            }
        }
        if (playerState == jumpState && Mathf.Abs(rb.velocity.y) <= 0.00001)
        {
            groundcheckCount2 += 1;
            if (groundcheckCount2 >= 20)
            {
                playerState = groundState;
                groundcheckCount2 = 0;
            }
        }
        if (playerState == parachuteDOWNState && Mathf.Abs(rb.velocity.y) <= 0.00001)
        {
            groundcheckCount3 += 1;
            if (groundcheckCount3 >= 20)
            {
                playerState = groundState;
                groundcheckCount3 = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Updraft"))
        {
            updraftPos = other.transform.position;
            updraftScl = other.transform.localScale;
            inUpdraft = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Updraft"))
        {
            inUpdraft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Updraft"))
        {
            inUpdraft = false;
        }
    }
}
