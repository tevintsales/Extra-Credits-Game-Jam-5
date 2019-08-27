using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExit : MonoBehaviour
{
    [Header("Place to transition to")]
    public int sceneToTransitionTo;
    public GameObject MenuTransPanel;

    Animator animator;

    void Start()
    {
        MenuTransPanel = GameObject.Find("MenuTransitionPanel");
        animator = MenuTransPanel.GetComponent<Animator>();
    }

    public void CallTransition(){
    	StartCoroutine(LoadSceneAFterTransition());
    }

    private IEnumerator LoadSceneAFterTransition()
    {
            animator.SetBool("animateOut", true);
            yield return new WaitForSeconds(1f);
            GameManager.instance.transitionActive = true;
            //load the scene we want
            LoadManager.instance.LoadScene(sceneToTransitionTo);
            animator.Play("MenuAnimIn", -1, 0f);
            animator.SetBool("animateOut", false);
        GameManager.instance.transitionActive = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
