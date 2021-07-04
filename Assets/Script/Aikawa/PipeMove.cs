using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject floor;
    void Update(){
        if(transform.position.y>(-10.0f))
            PipeMoveDown();
        else
            gameObject.SetActive(false);
    }
    private void PipeMoveDown(){
        transform.position -= new Vector3(0,speed,0)*Time.deltaTime;
    }
}
