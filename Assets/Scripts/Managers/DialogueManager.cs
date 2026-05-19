using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    [SerializeField] private DialogueUI dialogueUI;

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
        // subscribe to inventory events
        GameEvents.InspectionItemClicked += ShowDialogue;
    }
    private void OnDisable()
    {
        // unsubscribe from inventory events
        GameEvents.InspectionItemClicked -= ShowDialogue;
    }

    // function to display dialogue, called from events when player interacts with objects or picks up items
    public void ShowDialogue(string text)
    {
        dialogueUI.Show(text);
    }

    public void HideDialogue()
    {
        dialogueUI.Hide();
    }
}
