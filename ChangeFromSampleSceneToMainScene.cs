using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeFromSampleSceneToMainScene : MonoBehaviour
{
   /** void Awake()
    {
        SceneManager.LoadScene("Earth", LoadSceneMode.Single);
    }*/
    public void ChangeScene()
    {
        print("mate");
        SceneManager.LoadScene("Earth", LoadSceneMode.Single);
    }
}
