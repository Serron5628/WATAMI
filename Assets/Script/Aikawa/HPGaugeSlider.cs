using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class HPGaugeSlider : MonoBehaviour
{
    public GameObject Camera;
    public GameObject preHPGauge;
    private HPGauge hPGauge;
    private Slider slider;
    private int maxHp = 100, hp;
    float inputHorizontal;
    float inputVertical;

    private void Awake()
    {
        hp = maxHp;
    }

    // Use this for initialization
    void Start()
    {
        GameObject objCanvas = GameObject.Find("Canvas");
        GameObject objHPGauge = (GameObject)Instantiate(preHPGauge, objCanvas.transform);
        hPGauge = objHPGauge.GetComponent<HPGauge>();
        hPGauge.MaxHP = maxHp;
        slider = gameObject.GetComponent<Slider>();
        slider.value = (float)hp / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Canvas").transform.LookAt(Camera.transform);
        hp = Mathf.FloorToInt(maxHp * slider.value);
        hPGauge.HP = hp;
    }
}