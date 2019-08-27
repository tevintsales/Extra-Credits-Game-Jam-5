using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

	public bool isLocked = true;
	
	//allows Multiple Locks / Unlocks
	public bool isMultiLock = false;
	//add from the object unlocking
	public int numOfUnlocks = 0;
	//if numOfUnlocks >= totalLocks then unlock the door
	public int totalLocks = 3;

    // Start is called before the first frame update
    void Start()
    {
    	//just setting them here for testing
        isLocked = true;
        isMultiLock = true;

    }

    // Update is called once per frame
    void Update()
    {
    	//if the door is multilocked, multiple things need to be unlocked correctly
    	if (isMultiLock == true && numOfUnlocks >= totalLocks) {
    		isLocked = false;
    	}
    	//if the door is unlocked destroy it
    	if (isLocked == false) {
    		this.gameObject.SetActive(false);
    		//Destroy(this.gameObject);
    	}
    }
}
