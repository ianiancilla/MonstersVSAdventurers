using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int splashScreenTime = 3;


    // Start is called before the first frame update
    void Start()
    {
        IfOnSplashLoadStart();
    }

    private void IfOnSplashLoadStart()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(WaitForTime(splashScreenTime));
        }
    }

    IEnumerator WaitForTime(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("YouLose");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLev1()
    {
        SceneManager.LoadScene("Level 1");
    }
}
