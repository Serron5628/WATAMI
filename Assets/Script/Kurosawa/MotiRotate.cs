using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MotiRotate : MonoBehaviour
{
    public GameObject Player;
    public GameObject kogane_wait;
    CanMove canmove;
    Vector2 mPos;
    Vector2 screenSizeHalf;
    public MotiHuge HUGE;
    float previousRad;
    float tan = 0f;
    float RotationCount = 0;
    bool action = false;

    public float FirstSpeed;
    public float UpSpeed;
    public float MaxSpeed;

    private CriAtomSource MotiWind;
    public GameObject MotiSound;

    void OnFire(InputValue input)
    {
        var pressed = input.isPressed;

        action = pressed;

        if (!pressed)
        {
            tan = FirstSpeed;
            RotationCount = 0;
        }
    }

    void OnMoveOnScreen(InputValue input)
    {
        mPos = input.Get<Vector2>() - screenSizeHalf;
    }

    // Start is called before the first frame update
    void Start()
    {
        tan = FirstSpeed;

        // 画面の縦横の半分 
        screenSizeHalf.x = Screen.width / 2f;
        screenSizeHalf.y = Screen.height / 2f;

        // マウスの初期位置
        mPos = new Vector2(0.0f, 0.0f);
        /*mPos = Input.mousePosition - screenSizeHalf;
        previousRad = Mathf.Atan2(mPos.x, mPos.y);*/

        canmove = kogane_wait.GetComponent<CanMove>();

        MotiWind = MotiSound.GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        // 真ん中が(0,0,0)になるようにマウスの位置を取得
        //mPos = Input.mousePosition - screenSizeHalf;

        float rad = Mathf.Atan2(mPos.x, mPos.y); // 上向きとマウス位置のなす角
        float dRad = rad - previousRad; // 前のフレームの角度との差
        if (canmove.CanMoveFlag)
        {
            if (action)
            {
                if (RotationCount == 0)
                {
                    HUGE.ResetE();//餅の大きさリセット
                }
                tan += Mathf.Abs(dRad); //タンジェント // * mPos.magnitude;

                if(tan >= MaxSpeed)
                {
                    tan = MaxSpeed;
                }

                Player.transform.Rotate(new Vector3(0, tan / 10, 0));//プレイヤーの回転

                if (dRad > 1 || dRad < -1) //フレームの角度の差が1以上あれば餅伸ばし実行
                {
                    RotationCount += 1;//回転数
                    if (RotationCount == 1)
                    {
                        HUGE.KeepScale();
                    }

                    //ここで餅の回転する音を鳴らす
                    MotiWind.Play();

                }
                if (RotationCount > 4)
                {
                    HUGE.hugeScale();//餅伸ばし開始
                }
            }
        }
        previousRad = rad; // 今のフレームの角度を保存
    }

    public void SpeedUp()
    {
        tan += UpSpeed;
    }
}

