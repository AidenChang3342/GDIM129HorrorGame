using UnityEngine;
using System.Collections.Generic;

public class SnackItem : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private ItemData snackItem;
    [SerializeField] private List<string> dialogueLines;

    private void Start()
    {
        // Hide snack if player already got it before
        if (GameManager.instance.snackFound)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while inventory is open");
            return;
        }

        if (DialogueManager.instance.isDialogueActive)
        {
            Debug.Log("Cannot interact while dialogue is active");
            return;
        }

        PickupSnack();
    }

    private void PickupSnack()
    {
        AudioManager.instance.PlaySFX(pickupSFX, transform, 0.5f);

        DialogueManager.instance.StartDialogue(dialogueLines);
        InventoryManager.instance.AddItem(snackItem);

        GameManager.instance.snackFound = true;

        gameObject.SetActive(false);
    }
}