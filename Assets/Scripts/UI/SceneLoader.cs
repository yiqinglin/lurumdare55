using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneNameToLoad; // Name of the scene to load

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}