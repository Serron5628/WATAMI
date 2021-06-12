using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSceneButton : MonoBehaviour
{
    public string nextStageName;
    string pushStage;
    [SerializeField]
    float waitTime;
    public void NextScene()
    {
        pushStage = nextStageName;
        Invoke("ChangeScene", waitTime);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(pushStage);
    }
}
