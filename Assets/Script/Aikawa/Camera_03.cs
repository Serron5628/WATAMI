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
public class Camera_03 : MonoBehaviour{
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
    [SerializeField] private int cameraMoveSpeed = 200;
    
    float dis,disdata;
    Ray ray;
    Vector3 CameraPos1;
    List<string> tagList = new List<string>();
    void Start(){
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
            if(dis+0.2f<=distance&&
                hit.collider.tag !="Moti"&&
                hit.collider.tag !="Player"&&
                hit.collider.tag !="enemy"&&
                hit.collider.tag !="StartWall"&&
                hit.collider.tag !="LastAttack"
                )minusDistance();
        }else plusDistance();
        if(Input.GetKey(KeyCode.Q))
            azimuthalAngle -= Time.deltaTime * cameraMoveSpeed;
        if(Input.GetKey(KeyCode.E))
            azimuthalAngle += Time.deltaTime * cameraMoveSpeed;
        if(Input.GetKey(KeyCode.Alpha2))
            polarAngle -= Time.deltaTime * cameraMoveSpeed;
        if(Input.GetKey(KeyCode.X))
            polarAngle += Time.deltaTime * cameraMoveSpeed;
        var lookAtPos = PlayerPos + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }
    public void minusDistance(){
        distance = dis;
    }
    public void plusDistance(){
        if(disdata>distance+0.2f) distance += disZoomSpeed * Time.deltaTime;
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
