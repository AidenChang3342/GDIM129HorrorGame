using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SnackItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private ItemData snackItem;
    [SerializeField] private List<string> dialogueLines;
    [SerializeField]private Image snackItemImage;

    private void Start()
    {
        // Hide snack if player already got it before
        if (GameManager.instance.snackFound)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        snackItemImage.enabled = true;
    }

    public void OnPointerDown(PointerEventData eventData)
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

        snackItemImage.enabled = false;
    }
}