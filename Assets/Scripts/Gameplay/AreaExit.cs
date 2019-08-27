using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaExit : MonoBehaviour
{
    [Header("Place to transition to")]
    public int sceneToTransitionTo;
    public int songToPlay = 0;
    public GameObject SceneTransPanel = null;
    public GameObject MenuTransPanel = null;

    public Animator animatorMenu = null;
    public Animator animatorScenes = null;
    
    //public int currentScene = 0;

    void Start()
    {

        //sets the animator upon opening
        MenuTransPanel = GameObject.Find("MenuTransitionPanel");
        animatorMenu = MenuTransPanel.GetComponent<Animator>();

        SceneTransPanel = GameObject.Find("SceneTransitionPanel");
        animatorScenes = SceneTransPanel.GetComponent<Animator>();

        //Grabs the two separate animator controls that handle the different animations

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadSceneAFterTransition());
        }
    }

    private IEnumerator LoadSceneAFterTransition()
    {
    	if (sceneToTransitionTo == 0) {
            animatorMenu.SetBool("animateOut", true);
            GameManager.instance.transitionActive = true;
            yield return new WaitForSeconds(1f);
            GameManager.instance.transitionActive = false;
            //load the scene we want
            LoadManager.instance.LoadScene(sceneToTransitionTo);
            //animatorMenu.Play("SceneTransAnimIn", -1, 0f);
        }
    	if (sceneToTransitionTo != 0) {
            animatorScenes.SetBool("animateOut", true);
            AudioController.instance.PlayBGM(songToPlay);
            GameManager.instance.songToPlay = songToPlay;
            GameManager.instance.transitionActive = true;
            yield return new WaitForSeconds(1f);
            GameManager.instance.transitionActive = false;
            //load the scene we want
            LoadManager.instance.LoadScene(sceneToTransitionTo);
            animatorScenes.Play("SceneTransAnimIn", -1, 0f);
            animatorScenes.SetBool("animateOut", false);
        }
    }
}
