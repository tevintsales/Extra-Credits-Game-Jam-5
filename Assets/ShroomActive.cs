using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomActive : MonoBehaviour
{
    public GameObject[] objectsToShow;

    // Update is called once per frame
    void Update()
    {
        if (EventManager.instance.IsEventActivated(0))
        {
            for(int i = 0; i < objectsToShow.Length; i++)
            {
                objectsToShow[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < objectsToShow.Length; i++)
            {
                objectsToShow[i].SetActive(false);
            }
        }
    }
}
