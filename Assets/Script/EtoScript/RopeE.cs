using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeE : MonoBehaviour
{
    public GameObject[] himo = new GameObject[5];
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.positionCount = himo.Length;

        foreach(GameObject v in himo)
        {
            v.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int idx = 0;
        foreach (GameObject v in himo)
        {
            line.SetPosition(idx, v.transform.position);
            idx++;
        }
    }
}
