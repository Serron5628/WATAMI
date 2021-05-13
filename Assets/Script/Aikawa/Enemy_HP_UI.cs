using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP_UI : MonoBehaviour
{
    public GameObject EnemyHP;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 UIPos = this.transform.position;
        Instantiate(EnemyHP, UIPos, Quaternion.identity);
    }
    private void Update()
    {
        GameObject camera= GameObject.Find("Main Camara");
        Vector3 UIPos = this.transform.position;
        EnemyHP.transform.position = UIPos;
        EnemyHP.transform.LookAt(camera.transform);
    }
}
