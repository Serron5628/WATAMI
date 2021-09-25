using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyDestroy_02 : MonoBehaviour
{
    public int childNumber = 0;
    int count = 0;
    [SerializeField] private GameObject[] ParentObject;
    public GameObject[] ChildObject;

    private void GetAllChildObject()
    {
        childNumber = 0;
        count = 0;
        for (int i = 0; i < ParentObject.Length; i++)
        {
            childNumber += ParentObject[i].transform.childCount;
        }
        ChildObject = new GameObject[childNumber];
        for (int j = 0; j < ParentObject.Length; j++)
        {
            for (int i = 0; i < ParentObject[j].transform.childCount; i++)
            {
                if (ParentObject[j].transform.GetChild(i).tag == "enemy")
                {
                    //ParentObject[j].transform.GetChild(i).tag = "enemy";
                    ChildObject[count] = ParentObject[j].transform.GetChild(i).gameObject;
                    count++;
                }
            }
        }
    }
    public void DestroyEnemy()
    {
        count = 0;
        for (int j = 0; j < ParentObject.Length; j++)
        {
            for (int i = 0; i < ParentObject[j].transform.childCount; i++)
            {
                if (ParentObject[j].transform.GetChild(i).tag == "enemy")
                {
                    Destroy(ChildObject[count]);
                    count++;
                }
            }
        }
    }
}
