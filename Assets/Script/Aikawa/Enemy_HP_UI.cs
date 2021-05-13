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
        StartCoroutine(DelayCoroutine());
    }
    private IEnumerator DelayCoroutine()
    {
        transform.position = Vector3.one;

        // 3秒間待つ
        yield return new WaitForSeconds(3);

        // 3秒後に原点にワープ
        transform.position = Vector3.zero;
    }
    private void Update()
    {
        GameObject camera = GameObject.Find("Main Camara");
        Vector3 UIPos = this.transform.position;
        EnemyHP.transform.position = UIPos;
        EnemyHP.transform.LookAt(camera.transform);
    }
    int cntD = 0;
    private void FixedUpdate()
    {
        cntD += 1;
        if (cntD >= 600)
        {
            Destroy(this.gameObject);
            Destroy(EnemyHP);
        }
    }
}
