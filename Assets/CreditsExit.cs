using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsExit : MonoBehaviour
{
    [Header("Place to transition to")]
    public int sceneToTransitionTo = 1;
    public int songToPlay = 0;
    
    public GameObject EndTransPanel = null;
    public Animator animatorEnd = null;

    public GameObject MenuTransPanel = null;
    public Animator animatorMenu = null;
    //public int currentScene = 0;

    void Start()
    {
        EndTransPanel = GameObject.Find("EndingCreditsPanel");

        animatorEnd = EndTransPanel.GetComponent<Animator>();

    }

    public void GoToMainHub()
    {
        AudioController.instance.PlayBGM(songToPlay);
        GameManager.instance.transitionActive = false;
        LoadManager.instance.LoadScene(sceneToTransitionTo);
        animatorEnd.Play("CreditsNoImage", -1, 0f);
        animatorEnd.SetBool("endTriggered", false);
    }
}
