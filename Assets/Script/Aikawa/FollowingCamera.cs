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
    public GameObject player;
    public GameObject playerCenter;// an object to follow
    public Vector3 offset; // offset form the target object
    public GameObject camera_view = null;
    bool flag = true;//カメラの固定
    bool flag2 = true;//カメラのズーム

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

    //lockOn
    [SerializeField] private float cX = 0.0f;
    [SerializeField] private float cY = 3.0f;
    [SerializeField] private float cZ = -5.0f;

    bool Elock;
    private void Start()
    {
        distance = 10.0f;
        Elock = false;
    }
    
    float disdata;
    private void OnCollisionEnter(Collision collision)
    {
        if (distance > reDistance) disdata = distance;
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 PlayerPos = player.transform.position;
        Ray ray = new Ray(PlayerPos, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            float dist = Vector3.Distance(PlayerPos, hit.point);
            if (distance > dist) distance = dist;
        }
        else

            Debug.DrawLine(PlayerPos, transform.position, Color.magenta, 0f, false);
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
        updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));
        var lookAtPos = player.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);

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

    public void enemyFlag()
    {
        if (Elock == false)
        {
            Elock = true;
            Debug.Log("A");
        }

        else if (Elock == true) Elock = false;
    }
    public void enemyFlagDistance()
    {
        distance = maxDistance;
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
            if (Elock == false)
            {
                x = azimuthalAngle - x * mouseXSensitivity * mouserotaXSpd;
                y = polarAngle + y * mouseYSensitivity * mouserotaYSpd;
                azimuthalAngle = Mathf.Repeat(x, 360);
                polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
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
        if (Elock == false)
        {
            scroll = distance - scroll * scrollSensitivity;
            distance = Mathf.Clamp(scroll, minDistance, maxDistance);
        }
    }
    void updatePosition(Vector3 lookAtPos)
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        if (Elock == false)
        {
            transform.position = new Vector3(
                lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
                lookAtPos.y + distance * Mathf.Cos(dp),
                lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
        }
        else transform.localPosition = new Vector3(cX, cY, cZ);
    }
}