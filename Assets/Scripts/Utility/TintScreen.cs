using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintScreen : MonoBehaviour
{
    public GameObject tintScreen;
    // Update is called once per frame
    void Update()
    {
        if (EventManager.instance.IsEventActivated(0))
        {
            tintScreen.SetActive(true);
        }
        else
        {
            //Test
            tintScreen.SetActive(false);
        }
    }
}
