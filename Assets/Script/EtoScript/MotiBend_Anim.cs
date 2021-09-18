﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiBend_Anim : MonoBehaviour
{
    private Animator animator;

    private string bendStr = "isBend";
    private string motiStr = "IsMotiSize";
    bool MotiSizeAnim = false;

    Vector2 mPos;
    Vector3 screenSizeHalf;
    float previousRad;
    float tan = 0f;
    float RotationCount = 0;
    bool action = false;
    float mousu_move_x;
    float mousu_move_y;

    //float current_length = this.animator.GetFloat("Length");
    //public GameObject Player;
    //public MotiHuge HUGE;   
    // Start is called before the first frame update
    void Start()
    {
        mousu_move_x = Input.GetAxis("Mouse X");
        mousu_move_y = Input.GetAxis("Mouse Y");
        //自身のAnimatorを習得する
        this.animator = GetComponent<Animator>();
        this.animator.SetBool(motiStr, false);

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
        float blend = this.animator.GetFloat("Blend");
        float blend2 = this.animator.GetFloat("Blend2");
        if (Input.GetMouseButton(0))
        {
            //action = true;
            //this.animator.SetBool(bendStr, true);
            
            if((mousu_move_x>=0&&mousu_move_y>=0)|| (mousu_move_x >= 0 && mousu_move_y <= 0)|| (mousu_move_x <= 0 && mousu_move_y <= 0) || (mousu_move_x <= 0 && mousu_move_y <= 0))
            {
                
                blend = blend + 0.1f * Time.deltaTime;
                //blend2 = blend2 + 0.1f * Time.deltaTime;
                this.animator.SetFloat("Blend", blend);
                //this.animator.SetFloat("Blend2", blend2);
            }
            if ((mousu_move_x <= 0 && mousu_move_y >= 0) || (mousu_move_x <= 0 && mousu_move_y <= 0) || (mousu_move_x >= 0 && mousu_move_y <= 0) || (mousu_move_x >= 0 && mousu_move_y <= 0))
            {
                //blend2 = blend2 + 0.1f * Time.deltaTime;
                //this.animator.SetFloat("Blend2", blend2);
            }
            
            

            tan = 0;
            RotationCount = 0;
        }
        else
        {
            //action = false;
            //float blend = this.animator.GetFloat("Blend");
            blend = 0.0f;
            //float blend2 = this.animator.GetFloat("Blend2");
            blend2 = 0.0f;
            //blend = blend;
            this.animator.SetFloat("Blend", blend);
            this.animator.SetFloat("Blend2", blend2);

        }
        if (Input.GetMouseButtonUp(0))
        {
            MotiSizeAnim = true;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                MotiSizeAnim = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // 真ん中が(0,0,0)になるようにマウスの位置を取得
        mPos = Input.mousePosition - screenSizeHalf;

        float rad = Mathf.Atan2(mPos.x, mPos.y); // 上向きとマウス位置のなす角
        float dRad = rad - previousRad; // 前のフレームの角度との差
        if (action)
        {
            if (RotationCount == 0)
            {
                this.animator.SetBool(bendStr, false);
            }
            tan += Mathf.Tan(dRad); //タンジェント // * mPos.magnitude;
            //Player.transform.Rotate(new Vector3(0, tan / 10, 0));//プレイヤーの回転

        }
        previousRad = rad; // 今のフレームの角度を保存

        if (MotiSizeAnim)
        {
            this.animator.SetBool(motiStr, true);
        }
        else
        {
            if (MotiSizeAnim == false)
            {
                this.animator.SetBool(motiStr, false);
                //HUGE.ResetE();
            }
        }
    }
}
