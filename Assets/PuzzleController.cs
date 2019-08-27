using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public static PuzzleController instance = null;

    public GameObject puzzleWindow;
    public Text currentInputText;

    public string currentPattern = "";
    public string correctPattern = "";
    public string correctSecretPattern = "";
    public int eventIDToSet = 0;
    public int secretIDToSet = 0;
    // Start is called before the first frame update

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(this);
    }

    public void OpenPuzzleWindow(int eventID, int secretEventID)
    {
        currentInputText.text = currentPattern;
        puzzleWindow.SetActive(true);
        eventIDToSet = eventID;
        secretIDToSet = secretEventID;
        GameManager.instance.textActive = true;
    }

    public void ExitPuzzleWindow()
    {
        currentPattern = "";
        currentInputText.text = currentPattern;
        AudioController.instance.PlaySFX(0);
        puzzleWindow.SetActive(false);
        GameManager.instance.textActive = false;
    }

    public void ClearCurrentPattern()
    {
        currentPattern = "";
        AudioController.instance.PlaySFX(1);
        currentInputText.text = currentPattern;
    }

    public void CirclePressed()
    {
        currentPattern += "circle, ";
        AudioController.instance.PlaySFX(1);
        currentInputText.text = currentPattern;
    }
    public void SquarePressed()
    {
        currentPattern += "square, ";
        AudioController.instance.PlaySFX(1);
        currentInputText.text = currentPattern;
    }
    public void TrianglePressed()
    {
        currentPattern += "triangle, ";
        AudioController.instance.PlaySFX(1);
        currentInputText.text = currentPattern;
    }

    public void OnEnterPressed()
    {
        if(currentPattern == correctPattern)
        {
            EventManager.instance.ActivateEvent(eventIDToSet);
            AudioController.instance.PlaySFX(2);
        }
        else if(currentPattern == correctSecretPattern)
        {
            EventManager.instance.ActivateEvent(secretIDToSet);
            AudioController.instance.PlaySFX(2);
        }
        else
        {
            AudioController.instance.PlaySFX(3);
        }

        currentPattern = "";
        currentInputText.text = currentPattern;
        puzzleWindow.SetActive(false);
        GameManager.instance.textActive = false;
    }


}
