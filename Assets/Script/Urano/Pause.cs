using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f && pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
        }
        else if(Time.timeScale != 1.0f && pauseMenu.activeInHierarchy == false)
        {
            pauseMenu.SetActive(true);
        }
    }
}
