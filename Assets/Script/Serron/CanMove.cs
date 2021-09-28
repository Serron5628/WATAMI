using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMove : MonoBehaviour
{
    bool move;
    public bool CanMoveFlag;
    private float timecount;
    
    // Start is called before the first frame update
    void Start()
    {
        move = false;
        timecount = 0.0f;
        CanMoveFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timecount);
        if (move)
        {
            if (timecount > 1)
            {
                CanMoveFlag = true;
                move = false;
            }
            timecount += Time.deltaTime;
        }
    }

    public void CanMoveTrue()
    {
        timecount = 0;
        move = true;
    }
    public void CanMoveFalse()
    {
        CanMoveFlag = false;
    }
}
