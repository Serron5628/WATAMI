using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update

    public CriAtomSource PauseOpen;
    public CriAtomSource PauseClose;
    void Start()
    {
        //PauseOpen = GetComponent<CriAtomSource>();
        //PauseClose = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f && pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
            PauseClose.Play();
        }
        else if(Time.timeScale != 1.0f && pauseMenu.activeInHierarchy == false)
        {
            pauseMenu.SetActive(true);
            PauseOpen.Play();
        }
    }
}
