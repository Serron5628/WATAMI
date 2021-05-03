using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRopeClimb : MonoBehaviour
{
    bool RopeHit = false;
    bool isClimbing = false;
    float playerPosY;

    Vector3 HitPos;
    Vector3 center;

    public float climbSpeed;
    public float rotateSpeed;

    Rigidbody rb;
    PlayerMove playermoveScript;
    PlayerParachute parachuteScript;
    GroundCheck groundcheckScript;
    GameObject pointObj;
    Transform pointTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playermoveScript = GetComponent<PlayerMove>();
        parachuteScript = GetComponent<PlayerParachute>();
        groundcheckScript = GameObject.Find("GroundChecker").GetComponent<GroundCheck>();
        pointObj = new GameObject("RopePoint");
        pointObj.SetActive(false);
        pointTransform = pointObj.transform;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(RopeHit);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (isClimbing == true)
            {
                transform.position += new Vector3(0.0f, climbSpeed * Time.deltaTime, 0.0f);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (groundcheckScript.isGround == true)
            {
                isClimbing = false;
                rb.useGravity = true;
                playermoveScript.enabled = true;
                parachuteScript.enabled = true;
            }
            else
            {
                if (isClimbing == true)
                {
                    transform.position += new Vector3(0.0f, -climbSpeed * Time.deltaTime, 0.0f);
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (isClimbing == true)
            {
                var angeleAxis = Quaternion.AngleAxis(360 / 36 * rotateSpeed * Time.deltaTime, Vector3.up);
                var pos = transform.position;

                pos -= center;
                pos = angeleAxis * pos;
                pos += center;

                transform.position = pos;
                transform.rotation = transform.rotation * angeleAxis;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (isClimbing == true)
            {
                var angeleAxis = Quaternion.AngleAxis(-360 / 36 * rotateSpeed * Time.deltaTime, Vector3.up);
                var pos = transform.position;

                pos -= center;
                pos = angeleAxis * pos;
                pos += center;

                transform.position = pos;
                transform.rotation = transform.rotation * angeleAxis;
            }
        }
        //Debug.Log(isClimbing);

        //キャンセル行動
        if (Input.GetKey(KeyCode.B))
        {
            isClimbing = false;
            rb.useGravity = true;
            playermoveScript.enabled = true;
            parachuteScript.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rope"))
        {
            playerPosY = transform.position.y;

            playermoveScript.enabled = false;
            parachuteScript.enabled = false;
            isClimbing = true;
            center = collision.transform.position;
            rb.velocity = Vector3.zero;
            Vector3 ropeRotate = collision.transform.eulerAngles;
            RopeHit = true;

            foreach (ContactPoint point in collision.contacts)
            {
                HitPos = point.point;
                pointTransform.position = HitPos;
                pointTransform.eulerAngles = ropeRotate;
                //Debug.Log(HitPos);
            }

            pointTransform.parent = collision.transform;
            Vector3 localHit = pointTransform.localPosition;
            localHit.x = 0.0f;
            localHit.z = 0.0f;

            Vector3 localorigin = localHit;
            pointTransform.localPosition = localorigin;
            pointTransform.parent = null;

            Vector3 worldorigin = pointTransform.position;

            Vector3 vec = HitPos - worldorigin;
            Vector3 vecN = vec.normalized;

            float sclZ, collsclZ;
            sclZ = transform.localScale.z / 2;
            collsclZ = collision.transform.localScale.z / 2;

            //座標を円柱側面に
            vecN = (collsclZ + sclZ) * vecN;

            Vector3 pos = worldorigin + vecN;
            pointTransform.position = pos;

            //rb.isKinematic = true;
            rb.useGravity = false;

            float dist = (pos - worldorigin).magnitude;

            //プレイヤーの向きの指定
            transform.forward = -vec;

            transform.position = new Vector3(pos.x ,playerPosY,pos.z);

            //Debug.Log(dist);
            //Debug.Log(vec);
        }
        if (isClimbing == false)
        {
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rope"))
        {
            RopeHit = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rope"))
        {
            RopeHit = false;
        }
    }
}
