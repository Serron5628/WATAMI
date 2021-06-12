using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSetActiveButton : MonoBehaviour
{
    [SerializeField]
    float setActiveTime;
    public GameObject setObject;
    public void SetActive()
    {
        Invoke("ObjectSet", setActiveTime);
    }

    void ObjectSet()
    {
        if(setObject.activeSelf == true)
        {
            setObject.SetActive(false);
        }
        else
        {
            setObject.SetActive(true);
        }
    }
}
