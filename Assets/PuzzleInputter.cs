using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleInputter : MonoBehaviour
{
    private bool canInteract = false;
    public string correctPatternString = "";
    public string correctSecretPattern = "";
    public int eventIDToSet = 0;
    public int secretEventID = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract && !PuzzleController.instance.puzzleWindow.activeInHierarchy)
        {
            PuzzleController.instance.correctPattern = correctPatternString;
            PuzzleController.instance.correctSecretPattern = correctSecretPattern;
            PuzzleController.instance.OpenPuzzleWindow(eventIDToSet, secretEventID);
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
}
