using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPos : MonoBehaviour
{
    public GameObject under;
    Vector3 plusY = new Vector3(0.0f,1.5f,0.0f);
    private void FixedUpdate()
    {
        transform.position = under.transform.position + plusY;
    }
}
