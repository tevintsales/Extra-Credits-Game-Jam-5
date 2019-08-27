using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockpuzzle : MonoBehaviour
{
    EventManager eventManager;
    InteractiveObject interactiveObject;
    string[] activatedText = { "Something is written here in the moss.","FOUR, SQUARE." };
    string[] unactivatedText = { "Moss always grows on the North side. Or something like that. I wonder what's on the other sides of the rock"};
    bool leave = false;

    [SerializeField] bool touching;

    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        interactiveObject = gameObject.GetComponent<InteractiveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventManager.IsEventActivated(19) && eventManager.IsEventActivated(20) && eventManager.IsEventActivated(21))
        {
            eventManager.ActivateEvent(22);
        }
        if (touching  &&!leave&& Input.GetKey("e") && eventManager.IsEventActivated(22))
        {
            TextController.instance.ShowDialog(activatedText);
            leave = true;
            Debug.Log("Active");
        }
        if (touching && !leave&&Input.GetKey("e") && !eventManager.IsEventActivated(22))
        {
            TextController.instance.ShowDialog(unactivatedText);
            leave = true;
            Debug.Log("Deactive");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touching = true;
        leave = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
        leave = false;
    }
}
    
    

