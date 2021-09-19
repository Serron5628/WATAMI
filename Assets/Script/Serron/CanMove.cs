using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMove : MonoBehaviour
{
    public bool CanMoveFlag;
    // Start is called before the first frame update
    void Start()
    {
        CanMoveFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanMoveTrue()
    {
        CanMoveFlag = true;
    }
    public void CanMoveFalse()
    {
        CanMoveFlag = false;
    }
}
