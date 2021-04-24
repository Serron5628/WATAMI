using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiRotate : MonoBehaviour
{
//<<<<<<< HEAD
    [SerializeField] GameObject Player;
    Vector2 mPos;
    Vector3 screenSizeHalf;
    public MotiHuge HUGE;
    float rad;
    float previousRad;
    float tan = 0f;
    float RotationCount = 0;
    //=======
    //[SerializeField] GameObject Cube;

    //Vector2 mPos;
    //Vector3 screenSizeHalf;
    //float rad;
    //float previousRad;
    //float tan = 0f;
//>>>>>>> origin/master

    // Start is called before the first frame update
    void Start()
    {
        // 画面の縦横の半分 
        screenSizeHalf.x = Screen.width / 2f;
        screenSizeHalf.y = Screen.height / 2f;
        screenSizeHalf.z = 0f;

        // マウスの初期位置
        mPos = Input.mousePosition - screenSizeHalf;
        previousRad = Mathf.Atan2(mPos.x, mPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        // 真ん中が(0,0,0)になるようにマウスの位置を取得
        mPos = Input.mousePosition - screenSizeHalf;

        float rad = Mathf.Atan2(mPos.x, mPos.y); // 上向きとマウス位置のなす角
        float dRad = rad - previousRad; // 前のフレームの角度との差
        if (Input.GetMouseButton(0))
        {
            tan += Mathf.Tan(dRad); //タンジェント // * mPos.magnitude;
                                    //<<<<<<< HEAD
            Player.transform.Rotate(new Vector3(0, tan / 50, 0));//プレイヤーの回転

            if (dRad > 1 || dRad < -1) //フレームの角度の差が1以上あれば餅伸ばし実行
            {
                RotationCount += 1;//回転数
                HUGE.hugeScale();
            }
            if (RotationCount > 1)
            {
                HUGE.hugeScale();//餅伸ばし開始
            }
            //=======
            //Cube.transform.Rotate(new Vector3(0, tan / 50, 0));
//>>>>>>> origin/master
        }
        previousRad = rad; // 今のフレームの角度を保存
        if (Input.GetMouseButtonUp(0))
        {
            ////<<<<<<< HEAD
            RotationCount = 0;//回転数リセット
            tan = 0;
            HUGE.ResetE();//餅の大きさリセット
        }
    }
}

//=======
//tan = 0;
//        }
//    }
//}
//>>>>>>> origin/master
