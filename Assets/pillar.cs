using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar : MonoBehaviour
{
    EventManager eventManager;
    InteractiveObject interactiveObject;
    [SerializeField] string[] activatedText;
    [SerializeField] string[] unactivatedText;
    bool leave = false;

    [SerializeField] int pillarActive;
    

    [SerializeField] bool touching;

    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        interactiveObject = gameObject.GetComponent<InteractiveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touching && !leave && Input.GetKey("e") && pillarActive == 26)
        {
            TextController.instance.ShowDialog(activatedText);
            eventManager.ActivateEvent(pillarActive);
            leave = true;
            Debug.Log("Active");
        }

        else
        {
            if (touching && !leave && Input.GetKey("e") && eventManager.IsEventActivated(pillarActive - 1))
            {
                TextController.instance.ShowDialog(activatedText);
                eventManager.ActivateEvent(pillarActive);
                leave = true;
                Debug.Log("Active");
            }
            if (touching && !leave && Input.GetKey("e") && !eventManager.IsEventActivated(pillarActive - 1))
            {
                TextController.instance.ShowDialog(unactivatedText);
                resetPuzzle();
                leave = true;
                Debug.Log("Deactive");
            }
        }

    }

    private void resetPuzzle()
    {
        eventManager.DisableEvent(26);
        eventManager.DisableEvent(27);
        eventManager.DisableEvent(28);
        eventManager.DisableEvent(29);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touching = true;
        leave = false;
        Debug.Log("touching");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
        leave = false;
        Debug.Log("not touching");
    }
}
