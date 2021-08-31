using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeButton : MonoBehaviour
{
    [SerializeField]
    float timescale = 1.0f;
    public void SetTime()
    {
        Time.timeScale = timescale;
    }
}
