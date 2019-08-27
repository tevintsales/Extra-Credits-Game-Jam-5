using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnEvent : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;
    //public int eventid;
    
    public void ActivateObjectsOnEventOn(int eventid)
    {
        if (EventManager.instance.IsEventActivated(eventid))
        {
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(true);
            }
            for (int i = 0; i < objectsToDeactivate.Length; i++)
            {
                objectsToDeactivate[i].SetActive(false);
            }
        }
    }

    public void DeactivateObjectsOnEventOff(int eventid)
    {
        if (!EventManager.instance.IsEventActivated(eventid))
        {
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(false);
            }
            for (int i = 0; i < objectsToDeactivate.Length; i++)
            {
                objectsToDeactivate[i].SetActive(true);
            }
        }
    }
}
