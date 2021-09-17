using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMove(InputValue input)
    {
        var moveVec = input.Get<Vector2>();
        var moveVec3 = new Vector3(moveVec.x, 0.0f, moveVec.y);
        transform.position += moveVec3 * Time.deltaTime;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 1f * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.position -= transform.forward * 1f * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += transform.right * 1f * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position -= transform.right * 1f * Time.deltaTime;
        }
    }*/
}
