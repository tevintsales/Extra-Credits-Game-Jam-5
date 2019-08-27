using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   [SerializeField] InventoryItem[] playerInventory = new InventoryItem[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(InventoryItem item)
    {
        
        for(int index = 0; index < playerInventory.Length; index++)
        {
            if (playerInventory[index] == null)
            {
                playerInventory[index] = item;

                //destory item in scene after adding to inventory
                return;
            }
        }
        //display inventory full message
        return;
        
    }

    public InventoryItem SearchForItem(string itemName)
    {
        int index = 0;
        InventoryItem returnItem;
        foreach(InventoryItem item in playerInventory)
        {
            if (item.GetItemName() == itemName)
            {
                returnItem = playerInventory[index];
                playerInventory[index] = null;
                Destroy(playerInventory[index].gameObject);
                return returnItem;
                
            }
            index++;
        }
        return null ; 
    }

    
}
