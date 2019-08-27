using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetAxis("Horizontal")> 0.05)
        {
            myAnimator.SetBool("WalkingRight",true) ;
        }
        if (Input.GetAxis("Horizontal") < -0.05)
        {
            myAnimator.SetBool("WalkingLeft", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            myAnimator.SetBool("WalkingLeft", false);
            myAnimator.SetBool("WalkingRight", false);
        }
        if (Input.GetAxis("Vertical") > 0.05)
        {
            myAnimator.SetBool("WalkingUp", true);
        }
        if (Input.GetAxis("Vertical") < -0.05)
        {
            myAnimator.SetBool("WalkingDown", true);
        }
        if (Input.GetAxis("Vertical") ==0)
        {
            myAnimator.SetBool("WalkingUp", false);
            myAnimator.SetBool("WalkingDown", false);
        }
    }
}
