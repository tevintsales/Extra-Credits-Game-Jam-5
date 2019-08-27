using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
	public Transform teleportSpot;
	public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }

    void OnTriggerEnter2D(Collider2D other) {
    	other.transform.position = teleportSpot.transform.position;

        GameManager.instance.transitionActive = true;
        StartCoroutine(TurnOffScreen());
    }

    IEnumerator TurnOffScreen()
    { 
        yield return new WaitForSeconds(0.2f);
        GameManager.instance.transitionActive = false;
    }

}
