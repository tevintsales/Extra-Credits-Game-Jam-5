using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public static TextController instance = null;

    [Header("Text to show")]
    public string[] textLines;
    public bool isShowingText = false;
    private bool justStarted;
    public int currentLine = 0;

    //Ui for text
    public GameObject textPanel;
    public Text textPanelText;

    [Header("Used for player choice")]
    public GameObject questionPanel;
    public Text questionPanelText;
    private int eventID;
    private bool shouldDeactivateEvent;
    private ActivateOnEvent activateObjectsOnEvent;
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

    // Update is called once per frame
    void LateUpdate()
    {
        //if(GameManager.instance.isShowingText)
        //TODO: Create Game manager script to manage the current state the game is in.
        if (textPanel != null && textPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= textLines.Length)
                    {
                        textPanel.SetActive(false);
                        AudioController.instance.PlaySFX(0);
                        GameManager.instance.textActive = false;
                    }
                    else
                    {
                        textPanelText.text = textLines[currentLine];
                        AudioController.instance.PlaySFX(1);
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines)
    {
        textLines = newLines;

        currentLine = 0;

        textPanelText.text = textLines[currentLine];
        textPanel.SetActive(true);
        AudioController.instance.PlaySFX(1);

        justStarted = true;

        GameManager.instance.textActive = true;
    }

    public void ShowQuestion(string questionToAsk, int eventToActivate, bool shouldDeactivate, ActivateOnEvent activateOnEvent)
    {
        questionPanelText.text = questionToAsk;
        questionPanel.SetActive(true);
        eventID = eventToActivate;
        shouldDeactivateEvent = shouldDeactivate;
        activateObjectsOnEvent = activateOnEvent;
        AudioController.instance.PlaySFX(1);
        GameManager.instance.textActive = true;
    }

    public void AnswerQuestionYes()
    {
        //Activate the event specified
        if (shouldDeactivateEvent)
        {
            EventManager.instance.DisableEvent(eventID);
            activateObjectsOnEvent.DeactivateObjectsOnEventOff(eventID);
        }
        else
        {
            EventManager.instance.ActivateEvent(eventID);
            activateObjectsOnEvent.ActivateObjectsOnEventOn(eventID);
        }      
        AudioController.instance.PlaySFX(0);
        questionPanel.SetActive(false);
        GameManager.instance.textActive = false;
        eventID = -1;
    }

    public void AnswerQuestionNo()
    {
        questionPanel.SetActive(false);
        AudioController.instance.PlaySFX(0);
        GameManager.instance.textActive = false;
        eventID = -1;
    }
}
