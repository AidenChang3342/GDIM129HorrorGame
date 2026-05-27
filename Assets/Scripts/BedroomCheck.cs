using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BedroomCheck : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private AudioClip openSFX;

    private void OnMouseDown()
    {
        if (UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while inventory is opened");
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

            SceneManager.LoadScene("Hallway");
        }
    }
}
