using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeControls : MonoBehaviour
{
    public static bool controlsOn;
    [SerializeField]
    string afterSceneName;
    public GameObject controlCanvas;
    //public ToSceneButton toSceneButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsOn == false)
        {
            if (controlCanvas.activeSelf == true)
            {
                controlsOn = true;
            }
        }
        
        if (controlsOn == true)
        {
            //toSceneButton.nextStageName = afterSceneName;
            GetComponent<ToSceneButton>().nextStageName = afterSceneName;
        }
    }

    public void ToControlScene()
    {
        Invoke("ToControl", 0.01f);
    }

    void ToControl()
    {
        controlsOn = true;
    }
}
