using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    public float loadDelay = 1f;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(this);
    }

    public void LoadScene(int sceneToLoad)
    {
        StartCoroutine(LoadSceneWithDelay(sceneToLoad));
    }

    public void LoadSceneNoDelay(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator LoadSceneWithDelay(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        yield return new WaitForSeconds(loadDelay);
    }

}
