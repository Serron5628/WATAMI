using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSceneButton : MonoBehaviour
{
    [SerializeField]
    string nextStageName;
    [SerializeField]
    float waitTime;
    public void NextScene()
    {
        Invoke("ChangeScene", waitTime);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(nextStageName);
    }
}
