using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The camera added this script will follow the specified object.
/// The camera can be moved by left mouse drag and mouse wheel.
/// </summary>
[ExecuteInEditMode, DisallowMultipleComponent]
public class FollowingCamera : MonoBehaviour
{
    public GameObject player; // an object to follow
   // public GameObject enemy;
    public Vector3 offset; // offset form the target object
    public GameObject camera_view = null;
    bool flag = true;//カメラの固定
    bool flag2 = true;//カメラのズーム
    bool Lock = false;//ロックオンは"Q"でいいかなって思ってる
                      //bool flag3 = true;


    [SerializeField] private float distance = 7.0f; // distance from following object
    [SerializeField] private float polarAngle = 20.0f; // angle with y-axis
    [SerializeField] private float azimuthalAngle = 270.0f; // angle with x-axis
    [SerializeField] private float reDistance = 7.0f;

    [SerializeField] private float minDistance = 2.0f;
    [SerializeField] private float maxDistance = 20.0f;
    [SerializeField] private float minPolarAngle = 30.0f;
    [SerializeField] private float maxPolarAngle = 140.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;

    [SerializeField] private float mouserotaXSpd = 2.0f;
    [SerializeField] private float mouserotaYSpd = 1.0f;

    private GameObject Etarget;

    private void Start()
    {
        //flag = false;
        distance = 10.0f;
    }
    protected void OnTriggerEnter(Collider c) 
    {
        if (c.gameObject.tag == "Enemy")
        {
            Etarget = c.gameObject;
        }
    }

    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            Etarget = null;
        }
    }

    public GameObject getTarget()
    {
        return this.Etarget;
    }

    float disdata;
    private void OnCollisionEnter(Collision collision)
    {
        if (distance > reDistance) disdata = distance;
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 Target = player.transform.position;
        Ray ray = new Ray(Target, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            float dist = Vector3.Distance(Target, hit.point);
            if (distance > dist) distance = dist;
            Debug.Log(distance);
        }
        else

            Debug.DrawLine(Target, transform.position, Color.magenta, 0f, false);
    }
    private void OnCollisionExit(Collision collision)
    {
        flag2 = false;
    }
    private void FixedUpdate()
    {
        if (flag2 == false && distance < disdata) distance += 1.2f;
        else flag2 = true;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (flag == false) flag = true;
            else flag = false;
        }
        if (flag == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void LateUpdate()
    {
        updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));
        var lookAtPos = player.transform.position + offset;
        //var lookAtPosW = enemy.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }
    private void LockOn()
    { 

    }

    void updateAngle(float x, float y)
    {
        //Mouseの左長押しでCameraのアングル固定　//KeyboardでCamera固定
        if (Input.GetMouseButton(0) || flag == true)
        {
            if (!(camera_view == null))
            {
                Text view_text = camera_view.GetComponent<Text>();
                view_text.text = "カメラ固定 : ON";
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (Lock == false) Lock = true;
                else if (Lock == true) Lock = false;
            }
            if (Lock == false)
            {
                Debug.Log("Lock=false");
                x = azimuthalAngle - x * mouseXSensitivity * mouserotaXSpd;
                y = polarAngle + y * mouseYSensitivity * mouserotaYSpd;
                azimuthalAngle = Mathf.Repeat(x, 360);
                polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
            }
            else if (Lock == true)
            {
                Debug.Log("Lock=true");
                if (!Etarget)
                {
                    x = azimuthalAngle - x * mouseXSensitivity * mouserotaXSpd;
                    y = polarAngle + y * mouseYSensitivity * mouserotaYSpd;
                    azimuthalAngle = Mathf.Repeat(x, 360);
                    polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
                    //Transform Etransform = Etarget.transform;
                    //Vector3 Epos = Etransform.position;

                    //Epos.x = azimuthalAngle - Epos.x;
                    //Epos.y = polarAngle + Epos.y;
                    //azimuthalAngle = Mathf.Repeat(Epos.x, 360);
                    //polarAngle = Mathf.Clamp(Epos.y, minPolarAngle, maxPolarAngle);
                }
            }

            if (!(camera_view == null))
            {
                Text view_text = camera_view.GetComponent<Text>();
                view_text.text = "カメラ固定 : OFF";
            }
        }
    }
    void updateDistance(float scroll)
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }
    void updatePosition(Vector3 lookAtPos)
    {
        //多分ここらへんでCameraの座標いじってる
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
}
