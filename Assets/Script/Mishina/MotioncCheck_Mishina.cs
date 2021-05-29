using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotioncCheck_Mishina : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { anim.SetTrigger("To_Run"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { anim.SetTrigger("To_Walk"); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { anim.SetTrigger("To_Rotation"); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { anim.SetTrigger("To_Wait"); }
    }
}
