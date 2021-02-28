using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;

    Rigidbody rb;
    GroundCheck groundCheck;

    public string playerState;
    string jumpState = "Jump";
    string groundState = "Ground";
    string fallState = "Fall";
    public string parachuteUPState = "Pup";
    
    //public float gravity;　　//（注）ゲーム全体の重力変更
    public float jumpUPPower;
    public float jumpForwardPower;
    public float gravity;
    float moveSpeed = 7.0f;

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
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGround == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
                || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
)
            {
                playerState = jumpState;
                rb.velocity = Vector3.zero;

                Vector3 v = transform.forward;
                Vector3 vn = v.normalized;

                Debug.Log(vn.x);
                Debug.Log(vn.z);
              
                rb.AddForce(vn.x * jumpForwardPower, jumpUPPower,vn.z * jumpForwardPower, ForceMode.Impulse);
            }
            else
            {
                playerState = jumpState;
                rb.velocity = Vector3.zero;
                rb.AddForce(0.0f, jumpUPPower, 0.0f, ForceMode.Impulse);
            }
        }

        if (rb.velocity.y < 0 && playerState != jumpState)
        {
            playerState = fallState;
        }
    }
}
