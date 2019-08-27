using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steak : MonoBehaviour
{
    string[] text1 = { "Thanks for the steak, Human. Here's something that should help.","THREE, TRIANGLE" };
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<steak>())
        {
            TextController.instance.ShowDialog(text1);
            Destroy(collision.gameObject);     
        }
    }
}
