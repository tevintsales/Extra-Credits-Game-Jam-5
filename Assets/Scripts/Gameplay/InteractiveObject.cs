using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [Header("Interaction Variables")]
    [Tooltip("If event is already activated, do something")]
    public bool hasInteracted;
    private bool canInteract = false;
    [Tooltip("If checked, asks player a question, will enable and event if yes is answered on the question" +
        "Needs to have questionToAsk field filled out")]
    public bool isPlayerChoice = false;
    [Tooltip("If checked, allows player to activate/deactivate game objects if the event is checked." +
        "Needs to have Activator for Event and Event not Enabled/Enabled Text filled out")]
    public bool checkIfActivated = false;
    public int[] eventID;

    [Tooltip("Actiavte event ID upon talked to")]
    public bool activateEventIfTalkedTo = false;
    [Tooltip("If enabled, deactiavates event upon talked to")]
    public bool deactivateEventID = false;
 

    [Header("Text to show on interaction")]
    public string[] interactionTextLines;
    [Header("Question Text to ask")]
    public string questionToAsk;
    [Header("Event Enabled Text")]
    public string[] ifEventIsActivatedText;
    [Header("Event not Enabled Text")]
    public string[] ifEventIsNotActivatedText;

    [Header("Activator for event")]
    public ActivateOnEvent eventActivator;
    //object variables
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E) && !TextController.instance.textPanel.activeInHierarchy && !TextController.instance.questionPanel.activeInHierarchy)
        {
            //If we just want to talk
            if(eventID.Length == 0)
            {
                TextController.instance.ShowDialog(interactionTextLines);
            }
            //If we want to remove objects by checking if event is activated
            else if (checkIfActivated && eventActivator != null)
            {
                for(int i = 0; i < eventID.Length; i++)
                {
                    if (EventManager.instance.IsEventActivated(eventID[i]))
                    {
                        TextController.instance.ShowDialog(ifEventIsActivatedText);
                        UpdateObjectsIfEventIsEnabled(eventID);
                    }                
                    else
                    {
                        TextController.instance.ShowDialog(ifEventIsNotActivatedText);
                    }
                }
            }
 
            //If we want to activate an event
            else
            {
                for (int i = 0; i < eventID.Length; i++)
                {
                    if (!isPlayerChoice)
                    {
                        TextController.instance.ShowDialog(interactionTextLines);
                        if (activateEventIfTalkedTo)
                        {
                            if (!deactivateEventID)
                            {
                                ActivateEvent(eventID);
                            }
                            else
                            {
                                DeactivateEvent(eventID);
                            }

                        }
                    }
                    else if (isPlayerChoice)
                    {
                        TextController.instance.ShowQuestion(questionToAsk, eventID[i], deactivateEventID, eventActivator);
                    }
                }
            }
         
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = false;    
        }
    }

    public void ResetObject()
    {
        gameObject.transform.position = startingPosition;
    }

    //Activate the event and it's objects if interactIfTalkedTo is enabled
    public void ActivateEvent(int[] eventID)
    {
        for (int i = 0; i < eventID.Length; i++)
        {
            EventManager.instance.ActivateEvent(eventID[i]);
            if(eventActivator != null)
            {
                eventActivator.ActivateObjectsOnEventOn(eventID[i]);
            }
            
        }
    }
    //Deactivate the event and it's objects if interactIfTalkedTo is enabled
    public void DeactivateEvent(int[] eventID)
    {
        for (int i = 0; i < eventID.Length; i++)
        {
            EventManager.instance.DisableEvent(eventID[i]);
            if(eventActivator != null)
            {
                eventActivator.DeactivateObjectsOnEventOff(eventID[i]);
            }         
        }
    }
    //Update all game objects in the activator if the event is enabled
    public void UpdateObjectsIfEventIsEnabled(int[] eventids)
    {
        for(int i = 0; i < eventID.Length; i++)
        {
            eventActivator.ActivateObjectsOnEventOn(eventids[i]);
            eventActivator.DeactivateObjectsOnEventOff(eventids[i]);
        } 
    }
}


