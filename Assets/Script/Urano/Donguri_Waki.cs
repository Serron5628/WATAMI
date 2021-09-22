using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donguri_Waki : MonoBehaviour
{
    public GameObject boss;
    public GameObject donguriTemp;
    public GameObject BurndonguriTemp;
    public GameObject stageObj;
    int count;
    [SerializeField]
    int countMax;
    [SerializeField]
    float radius;
    [SerializeField]
    float height;
    [SerializeField]
    int make;
    private CriAtomSource Fall;
    // Start is called before the first frame update
    void Start()
    {
        Fall = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count > countMax)
        {
            count -= countMax;
            for (int i = 0; i < make; i++)
            {

                GameObject donguri = Instantiate(donguriTemp, stageObj.transform);

                if(i%5 == 0)
                {
                    donguri = Instantiate(BurndonguriTemp, stageObj.transform);
                }
                Vector3 pos;
                while (true)
                {
                    pos.x = Random.Range(-1f, 1f);
                    pos.z = Random.Range(-1f, 1f);
                    var sqR = (pos.x * pos.x) + (pos.z * pos.z);
                    if (sqR < 1f)
                    {
                        break;
                    }
                }
                pos.x = pos.x * radius;
                pos.y = height;
                pos.z = pos.z * radius;
                donguri.transform.position = pos + gameObject.transform.position;
                donguri.SetActive(true);
                donguri.AddComponent<SphereCollider>().radius = 0.75f;
                donguri.AddComponent<Rigidbody>();
                donguri.GetComponent<EnemyMove>().enabled = false;
                donguri.GetComponent<MeshCollider>().enabled = false;
                donguri.AddComponent<Donguri_FirstSet>();

                if (i == 0)
                {
                    Fall.Play();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (boss.activeInHierarchy == true)
        {
            count++;
        }
    }
}
