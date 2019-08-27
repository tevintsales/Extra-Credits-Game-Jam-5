using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehaviour : MonoBehaviour
{
	//Attach this in Inspector
	public GameObject doorObj;
	//public Collider2D blockObjCol; 

	//DoorBehaviour Reference
	DoorBehaviour doorBehave;

    // Start is called before the first frame update
    void Start()
    {
    	doorObj = GameObject.Find("DoorObj");
    	doorBehave = doorObj.GetComponent<DoorBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
    	//If the Block Object is hitting the pressure plate
    	if (collider.gameObject.name == "BlockObj") {
    		//if the door needs multiple things to unlock it
    		if (doorBehave.isMultiLock == true){
    		//count up till door unlocks
    			doorBehave.numOfUnlocks += 1;
    		} else {
	    	//unlock the door obj
	    		doorBehave.isLocked = false;
    		}
    	}
    }
    void OnTriggerExit2D(Collider2D collider) {
    	//If the Block Object is hitting the pressure plate
    	if (collider.gameObject.name == "BlockObj") {
    		//if the door needs multiple things to unlock it
    		if (doorBehave.isMultiLock == true){
    		//count down for door unlocks
    			doorBehave.numOfUnlocks -= 1;
    		} else {
	    	//unlock the door obj
	    		doorBehave.isLocked = true;
    		}
    	}
    }
}
