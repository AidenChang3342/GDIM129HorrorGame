using UnityEngine;
using System.Collections.Generic;

public class BedroomCheck : MonoBehaviour
{
    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private AudioClip openSFX;

    private void OnMouseDown()
    {
        if (DialogueManager.instance.isDialogueActive)
        {
            Debug.Log("Cannot change scene while dialogue is active");
            return;
        }

        // if player clicks on door without finding clue, show dialogue
        if(GameManager.instance.bedroomClueFound == false)
        {
            DialogueManager.instance.StartDialogue(dialogueLines);
        }
        // if player clicks on door after finding clue, play sfx and load hallway scene
        if(GameManager.instance.bedroomClueFound == true)
        {
            AudioManager.instance.PlaySFX(openSFX, this.transform, 0.5f);

            GameManager.instance.ChangeScene("Hallway");
        }
    }
}
