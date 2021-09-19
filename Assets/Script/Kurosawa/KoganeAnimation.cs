using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KoganeAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    private string rotateStr = "isRotate";
    private string runStr = "isRun";

    bool mousePressed = false;

    void OnFire(InputValue input)
    {
        mousePressed = input.isPressed;

        //wait next Rotation
        this.animator.SetBool(rotateStr, mousePressed);
    }
    void OnMove(InputValue input)
    {
        var inputVec = input.Get<Vector2>();
        if (inputVec.x > 0.01f || inputVec.x < -0.01f || inputVec.y > 0.01f || inputVec.y < -0.01f)
        {
            this.animator.SetBool(runStr, true);
        }
        else
        {
            this.animator.SetBool(runStr, false);
        }
    }

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
