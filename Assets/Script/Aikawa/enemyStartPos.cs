using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStartPos : MonoBehaviour
{
    public GameObject Enemy;
    Vector3 UIPos = new Vector3(0.0f, 0.0f, 20.0f);
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy, UIPos, Quaternion.identity);
    }
    private void Update()
    {
        Enemy.transform.position = UIPos;
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(Enemy, new Vector3(0,4,0), Quaternion.identity);
        }
    }

}
