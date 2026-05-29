using UnityEngine;
using System.Collections.Generic;

public class KitchenClue : MonoBehaviour
{
    [SerializeField] private AudioClip scareSFX;
    [SerializeField] private AudioClip[] UISoundClip;
    [SerializeField] private GameObject breathMark;
    [SerializeField] private GameObject figure;
    [SerializeField] private ItemData clueItem;
    [SerializeField] private List<string> dialogueLines;
    private Camera mainCamera;
    private void Start()
    {
        // if clue has already been found, set gameobject to inactive
        if(GameManager.instance.kitchenClueFound)
        {
            this.gameObject.SetActive(false);
        }
        // set breath to inactive at start
        breathMark.SetActive(false);
        figure.SetActive(true);
        mainCamera = Camera.main;
    }
    // when player enters trigger, play scare sfx
    private void Update()
    {
        

        // if breath mark is inactive and figure is active, play scare sfx and set breath mark to active and figure to inactive
        if (figure.activeSelf)
        {
            // cast a ray from mouse position
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // if ray hits the figure collider, play scare sfx and set breath mark to active and figure to inactive
            if(
            hit.collider != null && 
            hit.collider.gameObject == figure && 
            (UIManager.instance.inventoryUI.isOpen == false) )
            {
                AudioManager.instance.PlaySFX(scareSFX, this.transform, 1f);
                breathMark.SetActive(true);
                figure.SetActive(false);
            }
        }

        // if breath mark is active and figure is inactive and breath mark is clicked, give clue
        if(
        breathMark.activeSelf && 
        Input.GetMouseButtonDown(0) && 
        UIManager.instance.inventoryUI.isOpen == false)
        {
            // cast a ray from mouse position
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // if ray hits the breath mark collider, give clue
            if(hit.collider != null && hit.collider.gameObject == breathMark)
            {
                AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 0.5f);
                
                // show dialogue
                DialogueManager.instance.StartDialogue(dialogueLines);

                // add to inventory
                InventoryManager.instance.AddItem(clueItem);

                // set clue as found in game manager
                GameManager.instance.kitchenClueFound = true;
                GameManager.instance.CheckClues();

                // hide breath mark
                breathMark.SetActive(false);
            }
        }        
    }
}
