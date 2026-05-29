using UnityEngine;
using System.Collections.Generic;

public class Fridge : MonoBehaviour
{
    // keypad object to set active/show
    [SerializeField] private GameObject keypad;
    // ui sfx
    [SerializeField] private AudioClip[] UISoundClip;
    [SerializeField] private List<string> noCluesDialogue;
    [SerializeField] private List<string> someCluesDialogue;
    [SerializeField] private List<string> allCluesDialogue;

    private void OnEnable()
    {
        // subscribe to events
        GameEvents.ActivateKeypad += ShowKeypad;
    }
    private void OnDisable()
    {
        // unsubscribe from  events
        GameEvents.ActivateKeypad -= ShowKeypad;
    }
    public void ShowKeypad()
    {
        if (keypad.activeSelf == false)
        {
            AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 1f);

            keypad.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        // prevents keypad from opening if inventory is open or dialogue is happening
        if (DialogueManager.instance.isDialogueActive || UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while dialogue/inventory open");
            return;
        }

        Debug.Log("Clicked Keypad ");

        if(GameManager.instance.anyClueFound == false)
        {
            DialogueManager.instance.StartDialogue(noCluesDialogue);
        }

        if(GameManager.instance.anyClueFound == true && GameManager.instance.allCluesFound == false)
        {
            DialogueManager.instance.StartDialogue(someCluesDialogue);    
        }

        if(GameManager.instance.allCluesFound == true)
        {
            GameManager.instance.shouldKeypadActivate = true;
            DialogueManager.instance.StartDialogue(allCluesDialogue);
        }
        AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 1f);
    }
}
