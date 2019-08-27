using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public CharacterControl controller;

    public float horizontalMove = 0f;
	public float verticalMove = 0f;
	float dodgecount = 0f;

	bool sneakPress = false;
	bool walkPress = false;
	bool dodgePress = false;

	bool isdodging = false;

	public bool canOpenInv = true;

	// Start
	void Start () {
        controller = GetComponent<CharacterControl>();
	}

	// Update is called once per frame
	void Update () {
		
		horizontalMove = Input.GetAxisRaw("Horizontal");
		verticalMove = Input.GetAxisRaw("Vertical");

		sneakPress = Input.GetButton("Sneak");
		walkPress = Input.GetButton("Walk");

		dodgePress = Input.GetButtonDown("Dodge");

        if (Input.GetButtonDown("Cancel") && !GameManager.instance.pauseActive)
        {
            GameManager.instance.pauseActive = true;
        }
        else if(Input.GetButtonDown("Cancel") && GameManager.instance.pauseActive)
        {
            GameManager.instance.pauseActive = false;
        }
	}

	// Reference the Controller
	void FixedUpdate () {

        //Dodge
        if (dodgePress == true && isdodging == false) {
            //Debug.Log("Space was pressed. Dodge");
            //Call Dodge Function
            controller.Dodge(horizontalMove, verticalMove);
            isdodging = true;
            dodgecount = 60;
            //Walking
        } else if (walkPress == true && isdodging == false) {
            //Debug.Log("Left Ctrl was pressed. Walking. 1/2 Move");
            //Call Controller Move Function
            controller.Walk(horizontalMove, verticalMove);
            //Sneaking
        } else if (sneakPress == true && isdodging == false) {
            //Debug.Log("Left Shift was pressed. Sneaking. 1/3 Move");
            //Call Controller Move Function
            controller.Sneak(horizontalMove, verticalMove);
        }
        //Move
        else if (GameManager.instance.textActive || GameManager.instance.pauseActive || GameManager.instance.transitionActive) {
            controller.StopMove();
        }
		else if (isdodging == false) {
			//Debug.Log("Move Normally");
			//Call Controller Move Function
			controller.Move(horizontalMove, verticalMove);
		}

	//Dodge Countdown 
		if (isdodging == true){
			dodgecount -= 1;
		}
		if (dodgecount > 0) {
			isdodging = false;
		}
		if (dodgecount < 0) {
			dodgecount = 0;
			}
	}
}
