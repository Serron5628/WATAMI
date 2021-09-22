using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class CameraMove : MonoBehaviour
{
    public GameObject player, playerParent;
    public Vector3 offset;
    
    private float distance = 9.0f; 
    [SerializeField] private float disZoomSpeed = 1.0f;
    [SerializeField] private float polarAngle = 80.0f; 
    [SerializeField] private float azimuthalAngle = 270.0f; 

    [SerializeField] private float minPolarAngle = 20.0f;
    [SerializeField] private float maxPolarAngle = 140.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float mouserotaXSpd = 2.0f;
    [SerializeField] private float mouserotaYSpd = 1.0f;
    
    private float dis, disdata, disZoomSpeedData;
    private float touchTime = 0.0f;
    private GameObject hitObj;
    private bool mousePressed = false;

    Vector2 lookVector;

    void OnFire(InputValue input){
        mousePressed = input.isPressed;
    }
    void OnLook(InputValue input){
        lookVector = input.Get<Vector2>();
    }

    void Start(){
        disdata = distance;
        lookVector = new Vector2(0.0f, 0.0f);
    }
    void FixedUpdate(){
        RaycastHit hit;
        if (!mousePressed){
            updateAngle(lookVector.x, lookVector.y);
        }

        Vector3 playerPos = player.transform.position;
        Vector3 playerParentPos = playerParent.transform.position;

        Debug.DrawLine(playerPos + offset, transform.position, Color.magenta, 0f, false);

        if (Physics.Linecast(playerPos + offset, transform.position, out hit)){
            touchTime = 0.0f;
            dis = Vector3.Distance(playerPos + offset, hit.point);
            hitObj = hit.collider.gameObject;
            if(dis - 2.0f <= distance &&(
                hit.collider.tag =="Floor"||
                hit.collider.tag =="Wall"||
                hit.collider.tag =="Ground"
            ))minusDistance();
        }
        else if(distance < disdata){
            if(touchTime < 10){
                touchTime += Time.deltaTime;
            }
            plusDistance();
        }
        var lookAtPos = new Vector3(playerParentPos.x,playerPos.y,playerParentPos.z) + offset;

        updatePosition(lookAtPos);
        this.transform.LookAt(lookAtPos);

        if(touchTime > 0.2f){
            disZoomSpeed = 20.0f;
        }
        else{
            disZoomSpeed = 0;
        }
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
        transform.position = 
            new Vector3(
                lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
                lookAtPos.y + distance * Mathf.Cos(dp),
                lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da)
            );
    }
    
}
