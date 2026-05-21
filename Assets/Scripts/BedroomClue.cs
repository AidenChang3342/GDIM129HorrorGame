using UnityEngine;
using System.Collections.Generic;

public class BedroomClue : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private AudioClip[] UISoundClip;
    [SerializeField] private ItemData clueItem;
    [SerializeField] private List<string> dialogueLines;

    // on mouse click, play pickup sfx and show dialogue, then add clue to inventory
    // add later: add gamemanager to save picked up clues (this prevents key from returning when player leaves and comes back) 
    // implement unlocking door
    private void OnMouseDown()
    {
        if (UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while inventory is opened");
            return;
        }

        AudioManager.instance.PlaySFX(pickupSFX, this.transform, 0.5f);
        
        // show dialogue
        DialogueManager.instance.StartDialogue(dialogueLines);

        // add clue to inventory
        InventoryManager.instance.AddItem(clueItem);

        // remove object
        gameObject.SetActive(false);
    }

}
