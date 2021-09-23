using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAClear : MonoBehaviour
{
    public GameObject black;
    Image rend;
    public float darkSec;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        if (black.activeSelf == false)
        {
            black.SetActive(true);
        }
        rend = black.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        color = rend.color;
        color.a -= Time.deltaTime / (darkSec);
        rend.color = color;
        if (color.a < 0.0f)
        {
            Destroy(black.gameObject);
            Destroy(this);
        }
    }
}
