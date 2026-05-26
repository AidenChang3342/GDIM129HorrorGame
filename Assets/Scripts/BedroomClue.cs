using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BedroomClue : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private AudioClip[] UISoundClip;
    [SerializeField] private ItemData clueItem;
    [SerializeField] private List<string> dialogueLines;
    [Header("Key")]
    [SerializeField] private GameObject key;
    [SerializeField] private float keyShowTime = 3f;


    // on mouse click, play pickup sfx and show dialogue, then add clue to inventory
    // add later: add gamemanager to save picked up clues (this prevents key from returning when player leaves and comes back) 
    // implement unlocking door
    private void Start()
    {
        key.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while inventory is opened");
            return;
        }

        StartCoroutine(PickupRoutine());
    }

    private IEnumerator PickupRoutine()
    {
        AudioManager.instance.PlaySFX(pickupSFX, transform, 0.5f);

        key.SetActive(true);

        DialogueManager.instance.StartDialogue(dialogueLines);
        InventoryManager.instance.AddItem(clueItem);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(keyShowTime);

        key.SetActive(false);

        gameObject.SetActive(false);
    }
}
