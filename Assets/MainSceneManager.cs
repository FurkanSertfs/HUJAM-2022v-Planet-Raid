using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void PlayGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);

    }
    public void PlayTutoriol()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

    }
}
