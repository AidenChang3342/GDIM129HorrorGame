using UnityEngine;

public class DialogueInput : MonoBehaviour
{
    private void Update()
    {
        // check for input to advance dialogue
        if (Input.GetMouseButtonDown(0) && DialogueManager.instance.isDialogueActive)
        {
            DialogueManager.instance.AdvanceDialogue();
        }
    }
}
