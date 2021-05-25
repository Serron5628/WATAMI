using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeE : MonoBehaviour
{
    public Vector3 defaultScale = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {

        //Transform myTransform = this.transform;
        //Vector3 localAngle = myTransform.localEulerAngles;
        //localAngle.x = 0;
        //localAngle.y = 0;
        //localAngle.z = 0;
        //myTransform.localEulerAngles = localAngle;

        Vector3 lossScale = transform.lossyScale;
        Vector3 localScale = transform.localScale;
        transform.localScale = new Vector3(
            localScale.x / lossScale.x * defaultScale.x,
            localScale.y / lossScale.y * defaultScale.y,
            localScale.z / lossScale.z * defaultScale.z);
    }
}
