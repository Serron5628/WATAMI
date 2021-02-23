using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParachute : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMove player;
    Rigidbody rb;
    Vector3 pos;
    Vector3 updraftPos;
    Vector3 updraftScl;
    public float minFallSpeed;
    public float riseSpeed;
    bool useParachute = false;
    bool inUpdraft = false;
    bool reachEndPos = false;
    int tmp = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerMove>();
    }

    void FixedUpdate()
    {
        //下降時　終端速度(minFallSpeed)
        if (useParachute == true && inUpdraft == false && rb.velocity.y <= 0)
        {
            rb.mass = 1;
            rb.drag = 2;
            rb.useGravity = false;
            var target_velocity = new Vector3(0f, -minFallSpeed, 0f);
            rb.AddForce(target_velocity * rb.mass * rb.drag / (1f - rb.drag * Time.fixedDeltaTime));
            //Debug.Log(rb.velocity.magnitude);
        }
        //上昇時
        if (useParachute == true && inUpdraft == true)
        {
            player.playerState = player.parachuteUP;
            pos = transform.position;
            float nextPosY = pos.y + riseSpeed;
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
                    transform.Translate(0.0f, riseSpeed, 0.0f);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            useParachute = true;
        }
        else
        {
            rb.drag = 0;
            rb.useGravity = true;
            useParachute = false;
            tmp = 0;
            player.playerState = player.nullStr;
        }

        //Debug.Log(rb.velocity);
        //Debug.Log(pos);
        //Debug.Log(inUpdraft);
    }

    private void OnTriggerEnter(Collider other)
    {
        updraftPos = other.transform.position;
        updraftScl = other.transform.localScale;

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
