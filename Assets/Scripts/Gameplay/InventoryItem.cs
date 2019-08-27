using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] int eventID;
    EventManager eventManager;

    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    public string GetItemName()
    {
        return itemName;
    }

    public int GetEventID()
    {
        return eventID;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.GetComponent<CharacterControl>())
        {
            eventManager.ActivateEvent(eventID);
            Destroy(gameObject);
        }
        
    }


}
