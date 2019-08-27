using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingExit : MonoBehaviour
{
    public GameObject EndTransPanel = null;

    public Animator animatorEnd = null;

    // Start is called before the first frame update
    void Start()
    {
        EndTransPanel = GameObject.Find("EndingCreditsPanel");
        animatorEnd = EndTransPanel.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //animatorEnd.Play("Credits Closing Anim", -1, 0f);
            GameManager.instance.transitionActive = true;
            animatorEnd.SetBool("endTriggered", true);
            animatorEnd.Play("Credits Closing Anim", -1, 0f);
            //animatorEnd.SetBool("endIdle", true);
        }
    }
}
