using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyDestroy_02 : MonoBehaviour{
    [SerializeField] private GameObject ParentObject;
    private GameObject[] ChildObject;
    private void GetAllChildObject(){
        ChildObject = new GameObject[ParentObject.transform.childCount];
        for (int i = 0; i < ChildObject.Length; i++){
            if(ParentObject.transform.GetChild(i).tag == "enemy")
                ChildObject[i] = ParentObject.transform.GetChild(i).gameObject;
        }
    }
    public void DestroyEnemy(){
        for (int i = 0; i < ChildObject.Length; i++){
            if(ParentObject.transform.GetChild(i).tag == "enemy")
                Destroy(ChildObject[i]);
        }
    }
}
