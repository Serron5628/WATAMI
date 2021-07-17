using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField]
    float xSenter;
    [SerializeField]
    float zSenter;
    [SerializeField]
    float xWidth;
    [SerializeField]
    float zWidth;
    [SerializeField]
    float yMinimum;
    Vector3 enemyPos;
    public GameObject inCounter;
    EneDestCount counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = inCounter.GetComponent<EneDestCount>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyPos = this.gameObject.transform.position;
        if (xSenter - xWidth / 2 > enemyPos.x || xSenter + xWidth / 2 < enemyPos.x
            || zSenter - zWidth / 2 > enemyPos.z || zSenter + zWidth / 2 < enemyPos.z
            || yMinimum > enemyPos.y)
        {
            if (counter != null)
            {
                //counter.count--;
            }
            //Destroy(this.gameObject);
        }
    }
}
