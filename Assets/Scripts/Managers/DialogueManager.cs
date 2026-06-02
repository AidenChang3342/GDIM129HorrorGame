using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    [SerializeField] private DialogueUI dialogueUI;
    private List<string> dialogueLines = new List<string>();
    private int lineIndex = 0;
    public bool isDialogueActive = false;
    private bool ignoreNextClick = false;

    private void Awake()
    {
        // creating singleton to call from anywhere
        if (instance == null)
        {
            instance = this;
            // keep sounds playing between scenes
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        // subscribe to events
        GameEvents.OnUIReady += CacheUI;
    }
    private void OnDisable()
    {
        // unsubscribe from  events
        GameEvents.OnUIReady -= CacheUI;
    }

    // cache dialogueUI reference from UI manager to prevent errors
    private void CacheUI()
    {
        dialogueUI = UIManager.instance.dialogueUI;
    }

    // function to display dialogue, called from events when player interacts with objects or picks up items
    public void StartDialogue(List<string> lines)
    {
        if (lines == null || lines.Count == 0)
        {
            Debug.Log("no lines found");
            return;
        }

        dialogueLines = lines;
        lineIndex = 0;

        dialogueUI.Show();
        dialogueUI.SetText(dialogueLines[lineIndex]);
        
        // ignore next click to prevent accidentally skipping first line of dialogue when starting dialogue
        ignoreNextClick = true; 
        isDialogueActive = true;
    }

    // advance dialogue to next line, called when player clicks to advance dialogue
    public void AdvanceDialogue()
    {
        // if dialogue isn't active, ignore input
        if (!isDialogueActive) 
        {
            return;
        }

        // if on first line of dialogue, ignore click to prevent accidentally skipping second line of dialogue
        if (ignoreNextClick)
        {
            ignoreNextClick = false;
            return;
        }

        lineIndex++; // next line

        // if there are more lines, show next line, otherwise end dialogue
        if (lineIndex < dialogueLines.Count)
        {
            dialogueUI.SetText(dialogueLines[lineIndex]);
        }
        else
        {
            if(InspectionUI.instance.inspection.activeSelf)
            {
                InspectionUI.instance.CloseInspection();
            }
            if(GameManager.instance.shouldKeypadActivate && GameManager.instance.snackFound == false)
            {
                GameEvents.ActivateKeypad?.Invoke();
            }
            if(GameManager.instance.introDialoguePlayed == false)
            {
                GameManager.instance.introDialoguePlayed = true;
                GameEvents.IntroDialogueEnded?.Invoke();
            }
            if(GameManager.instance.snackFound)
            {
                GameManager.instance.StartEndingCutscene();
            }
            if(GameManager.instance.endingDialoguePlayed == false)
            {
                GameManager.instance.endingDialoguePlayed = true;
                GameEvents.EndingDialogueEnded?.Invoke();
            }
            HideDialogue();
        }
    }

    // clears dialogue and hides ui
    public void HideDialogue()
    {
        isDialogueActive = false;
        lineIndex = 0;

        dialogueUI.Hide();
    }
}
