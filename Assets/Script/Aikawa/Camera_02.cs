using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// The camera added this script will follow the specified object.
/// The camera can be moved by left mouse drag and mouse wheel.
/// </summary>
[ExecuteInEditMode, DisallowMultipleComponent]
public class Camera_02 : MonoBehaviour{
    public GameObject player;
    public GameObject camera_view;
    public Vector3 offset;
    
    bool cameraLock = true;
    [SerializeField] private float distance = 5.0f; 
    [SerializeField] private float disZoomSpeed = 20.0f;
    [SerializeField] private float polarAngle = 80.0f; 
    [SerializeField] private float azimuthalAngle = 270.0f; 

    [SerializeField] private float minPolarAngle = 20.0f;
    [SerializeField] private float maxPolarAngle = 140.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float mouserotaXSpd = 2.0f;
    [SerializeField] private float mouserotaYSpd = 1.0f;
    
    float dis,disdata;
    Ray ray;
    Vector3 CameraPos1;
    List<string> tagList = new List<string>();
    void Start(){
        Cursor.visible = false;
        distance = 6.0f;
        disdata = distance;
    }
    void Update(){
        RaycastHit hit;
        Vector3 PlayerPos = player.transform.position;
        ray = new Ray(PlayerPos, CameraPos1);
        Debug.DrawLine(PlayerPos, transform.position, Color.magenta, 0f, false);
        if (Physics.Linecast(PlayerPos,transform.position, out hit)) {
            dis = Vector3.Distance(PlayerPos,hit.point);
            if(hit.collider.tag !="Moti"&&
                hit.collider.tag !="Player"&&
                hit.collider.tag !="enemy"&&
                hit.collider.tag !="StartWall"&&
                hit.collider.tag !="LastAttack"
                )minusDistance();
        }
        else plusDistance();
        updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        var lookAtPos = PlayerPos + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }
    public void minusDistance(){
        if(distance>dis)distance = dis;
    }
    public void plusDistance(){
        if(disdata>distance+0.2f) distance += disZoomSpeed * Time.deltaTime;
    }

    void updateAngle(float x, float y){
        x = azimuthalAngle - x * mouseXSensitivity * mouserotaXSpd;
        y = polarAngle + y * mouseYSensitivity * mouserotaYSpd;
        azimuthalAngle = Mathf.Repeat(x, 360);
        polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
    }

    void updatePosition(Vector3 lookAtPos){
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
    
}
