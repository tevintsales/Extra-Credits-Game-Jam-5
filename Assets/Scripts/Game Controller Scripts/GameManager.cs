using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
       

    //State management bools
    public bool textActive = false; //if text is showing, don't allow player to move
    public bool transitionActive = false; //if player is in transition, don't allow player to move
    private bool checkingForChickenEnabled = true;
    public bool pauseActive = false;

    public int songToPlay = 0;

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
        if(EventManager.instance.IsEventActivated(0))
        {
            AudioController.instance.PlayBGM(1);
        }
        else
        {
            AudioController.instance.PlayBGM(songToPlay);
        }
  
        //Checking for chicken count, if all are found, set event 13 to true
        if( checkingForChickenEnabled && EventManager.instance.IsEventActivated(6) && EventManager.instance.IsEventActivated(11) && EventManager.instance.IsEventActivated(12))
        {
            checkingForChickenEnabled = false;
            EventManager.instance.ActivateEvent(13);
        }

    }


}
