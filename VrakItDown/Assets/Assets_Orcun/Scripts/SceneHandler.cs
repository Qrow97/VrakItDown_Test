using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;

        PlayerPrefs.SetInt("ActiveScene", activeScene);
    }

    public void LoadScene()
    {
        int activeScene = PlayerPrefs.GetInt("ActiveScene");

        //SceneManager.LoadScene(activeScene);

        //Note: In most cases, to avoid pauses or performance hiccups while loading,
        //you should use the asynchronous version of the LoadScene() command which is: LoadSceneAsync()

        //Loads the Scene asynchronously in the background
        StartCoroutine(LoadNewScene(activeScene));
    }

    IEnumerator LoadNewScene(int sceneBuildIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        asyncOperation.allowSceneActivation = true;

    }
}

