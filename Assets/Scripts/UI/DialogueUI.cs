using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialoguePanel;

    private void Start()
    {
        Hide();
    }

    // shows dialogue panel and sets text, called from DialogueManager
    // if time: add text scrolling and clicking to advance lines
    public void Show()
    {
        dialoguePanel.SetActive(true);
    }

    // hides dialogue panel, called from DialogueManager
    public void Hide()
    {
        dialoguePanel.SetActive(false);
    }

    // sets dialogue text to update text
    public void SetText(string text)
    {
        dialogueText.text = text;
    }
}
