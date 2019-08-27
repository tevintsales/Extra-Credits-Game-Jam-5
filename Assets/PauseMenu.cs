using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static PauseMenu instance = null;
    [Header("Pause Menu")]
    public GameObject pauseMenu;
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
        //AudioController.instance.PlayBGM(0);
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.pauseActive)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        GameManager.instance.pauseActive = false;
        AudioController.instance.PlaySFX(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
