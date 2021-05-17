using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGaugeSliderE : MonoBehaviour
{
    private int maxHp = 1, hp;
    public GameObject preHPGauge;
    public GameObject objCanvas;
    private HPGauge hPGauge;
    private Slider slider;
    public Canvas Canvas;

    private void Awake()
    {
        hp = maxHp;
    }

    // Use this for initialization
    void Start()
    {
        GameObject objHPGauge = (GameObject)Instantiate(preHPGauge, Canvas.transform);
        hPGauge = objHPGauge.GetComponent<HPGauge>();
        hPGauge.MaxHP = maxHp;
        slider = gameObject.GetComponent<Slider>();
        slider.value = (float)hp / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.Find("Main Camera");
        objCanvas.transform.LookAt(camera.transform);
       // GameObject.Find("CanvasE").transform.LookAt(camera.transform);
        hp = Mathf.FloorToInt(maxHp * slider.value);
        hPGauge.HP = hp;
    }
}