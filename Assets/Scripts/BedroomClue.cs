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
    private void Start()
    {
        // if clue has already been found, set gameobject to inactive
        if(GameManager.instance.bedroomClueFound)
        {
            this.gameObject.SetActive(false);
        }
        key.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while inventory is opened");
            return;
        }
        if (DialogueManager.instance.isDialogueActive)
        {
            Debug.Log("Cannot interact while dialogue is active");
            return;
        }

        // start pickup routine and set clue as found in game manager
        GameManager.instance.bedroomClueFound = true;
        //StartCoroutine(PickupRoutine());
        PickupClue();
        
    }
    /*
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
    */

    private void PickupClue()
    {
        AudioManager.instance.PlaySFX(pickupSFX, transform, 0.5f);


        DialogueManager.instance.StartDialogue(dialogueLines);
        InventoryManager.instance.AddItem(clueItem);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        gameObject.SetActive(false);
        GameManager.instance.bedroomClueFound = true;
    }
}
