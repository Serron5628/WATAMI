using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera01 : MonoBehaviour
{
    [SerializeField]
    float rayRotX;
    [SerializeField]
    float rayRotY;
    [SerializeField]
    float rayRotZ;
    [SerializeField]
    int distance;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, new Vector3(rayRotX, rayRotY, rayRotZ));

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        //int distance = 10;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
        //Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

        //もしRayにオブジェクトが衝突したら
        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
        if (Physics.Raycast(ray, out hit, distance))
        {
            float dist = Vector3.Distance(transform.position, hit.point);
            Debug.Log(dist);
            Debug.DrawLine(ray.origin, ray.direction * dist, Color.blue);
            cam.transform.position = hit.point;
        }
        else
        {
            Debug.Log(distance);
            Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);
            cam.transform.position = ray.direction * distance;
        }
    }
}
