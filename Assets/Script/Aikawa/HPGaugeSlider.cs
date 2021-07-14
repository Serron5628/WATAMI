﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGaugeSlider : MonoBehaviour
{
    private int maxHp = 1, hp;
    public GameObject Camera;
    public GameObject preHPGauge;
    private HPGauge hPGauge;
    private Slider slider;

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
        GameObject camera = GameObject.Find("Main Camera");
        GameObject.Find("Canvas").transform.LookAt(Camera.transform);
       // GameObject.Find("CanvasE").transform.LookAt(camera.transform);
        hp = Mathf.FloorToInt(maxHp * slider.value);
        hPGauge.HP = hp;
    }
}