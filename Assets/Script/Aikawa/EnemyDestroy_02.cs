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

    public int damage;
    public int DonguriNumber;
    public int BurnDonguriNumber;

    private void GetAllChildObject()
    {
        childNumber = 0;
        count = 0;
        DonguriNumber = 0;
        BurnDonguriNumber = 0;
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
                    ChildObject[count] = ParentObject[j].transform.GetChild(i).gameObject;
                    count++;
                }
                if (ParentObject[j].transform.GetChild(i).name == "Donguri" ||
                    ParentObject[j].transform.GetChild(i).name == "Donguri(Clone)")
                {
                    DonguriNumber++;
                }
                else if(ParentObject[j].transform.GetChild(i).name == "BurnDonguri" ||
                    ParentObject[j].transform.GetChild(i).name == "BurnDonguri(Clone)")
                {
                    BurnDonguriNumber++;
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
