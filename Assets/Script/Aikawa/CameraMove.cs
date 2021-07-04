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
public class CameraMove : MonoBehaviour{
    public GameObject player;
    public Vector3 offset;
    
    [SerializeField] private float distance = 7.0f; 
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
    private GameObject hitObj;
   
    void Start(){
        disdata = distance;
    }
    void Update(){
        RaycastHit hit;
        Vector3 playerPos = player.transform.position;
        Vector3 cameraPos1 = transform.position;
        //Ray ray = new Ray(playerPos + offset, cameraPos1);
        Debug.DrawLine(playerPos+offset, transform.position, Color.magenta, 0f, false);
        if (Physics.Linecast(playerPos+offset,transform.position, out hit)) {
            dis = Vector3.Distance(playerPos+offset,hit.point);
            hitObj = hit.collider.gameObject;
            if(dis+0.2f<=distance&&(
                hit.collider.tag =="Floor"||
                hit.collider.tag =="Wall"
            ))minusDistance();
        }
        else if(disdata>distance+0.2f)
            plusDistance();
        if(!(Input.GetMouseButton(0)))
            updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        var lookAtPos = playerPos + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }
    public void minusDistance(){
        distance = dis;
    }
    public void plusDistance(){
        distance += disZoomSpeed * Time.deltaTime;
    }

    public void updateAngle(float x, float y){
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
