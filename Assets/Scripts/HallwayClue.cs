using UnityEngine;
using System.Collections.Generic;

public class HallwayClue : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private AudioClip[] UISoundClip;
    [SerializeField] private ItemData clueItem;
    [SerializeField] private List<string> dialogueLines;
    private void Start()
    {
        // if clue has already been found, set gameobject to inactive
        if(GameManager.instance.hallwayClueFound)
        {
            this.gameObject.SetActive(false);
        }
    }

    // on mouse click, play pickup sfx and show closeup of object
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

        // deactivate object
        // later: interact with game manager and save data of clue being picked up
        gameObject.SetActive(false);
    }
}
