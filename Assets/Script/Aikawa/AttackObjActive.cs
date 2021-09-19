using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjActive : MonoBehaviour
{
    public GameObject obj;
    public void ActiveTrue()
    {
        obj.SetActive(true);
    }
    public void ActiveFalse()
    {
        obj.SetActive(false);
    }
}
