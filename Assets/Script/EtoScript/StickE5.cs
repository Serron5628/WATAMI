using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickE5 : MonoBehaviour
{
    public bool ReParent;

    public bool[] m = new bool[7];

    public GameObject[] moti = new GameObject[7];

    public DeleteE deleteE;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        ReParent = deleteE.reParent;
        for (int i = 1; i < m.Length; i++)
        {
            m[i] = true;
        }
        m[0] = false;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider collision)
    {
        for (int i = 0; i < moti.Length; ++i)
        {
            var objName = "mochi";
            if (i > 0) objName = $"mochi{i}";

            if (collision.gameObject.name == objName && m[i])
            {
                this.gameObject.transform.parent = moti[i].gameObject.transform;
                rb.isKinematic = true;

                // このインデックス以外のmのboolをfalseに設定
                for (int j = 0; j < moti.Length; ++j)
                {
                    if (j != i) m[j] = false;
                }
            }
        }
    }
}