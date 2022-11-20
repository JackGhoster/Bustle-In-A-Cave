using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public string sceneToOpen;
    
    public void OnStartButton()
    {
        SceneManager.LoadScene(sceneToOpen, LoadSceneMode.Single);
    }
}
