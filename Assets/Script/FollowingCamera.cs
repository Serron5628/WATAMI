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
    public GameObject target; // an object to follow
    public GameObject camdis;
    public Vector3 offset; // offset form the target object
    public GameObject camera_view = null;
    bool flag = false;
    //bool flag2 = true;

    [SerializeField] private float distance = 7.0f; // distance from following object
    [SerializeField] private float polarAngle = 20.0f; // angle with y-axis
    [SerializeField] private float azimuthalAngle = 270.0f; // angle with x-axis

    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float maxDistance = 10.0f;
    [SerializeField] private float minPolarAngle = 30.0f;
    [SerializeField] private float maxPolarAngle = 140.0f;

    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;
    private void Start()
    {
        distance = 10.0f;
    }
    float disdata;
    private void OnCollisionEnter(Collision collision)
    {
        disdata = distance;
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 Target = target.transform.position;
        Ray ray = new Ray(Target, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            float dist = Vector3.Distance(Target, hit.point);
            Debug.Log(distance);
            distance = dist;
        }
        Debug.DrawLine(Target, transform.position, Color.magenta, 0f, false);
    }
    private void OnCollisionExit(Collision collision)
    {
        distance = disdata;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (flag == false)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
    }
    void LateUpdate()
    {
        updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));
        var lookAtPos = target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }
    void updateAngle(float x, float y)
    {
        //Mouseの左長押しでCameraのアングル固定　//KeyboardでCamera固定
        if (Input.GetMouseButton(0) || flag == true)
        {
            Cursor.visible = true;
            //Debug.Log("trueです--------------------------------");

            Text view_text = camera_view.GetComponent<Text>();
            view_text.text = "カメラ固定 : ON";
        }
        else
        {
            //Debug.Log("falseです");
            x = azimuthalAngle - x * mouseXSensitivity;
            azimuthalAngle = Mathf.Repeat(x, 360);
            y = polarAngle + y * mouseYSensitivity;
            polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);

            Text view_text = camera_view.GetComponent<Text>();
            view_text.text = "カメラ固定 : OFF";
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