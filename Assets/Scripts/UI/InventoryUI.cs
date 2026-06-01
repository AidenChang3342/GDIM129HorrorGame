using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform itemParent;
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip[] uiSFX;
    public bool isOpen = false;
    private void OnEnable()
    {
        // subscribe to inventory events
        GameEvents.OnItemAdded += UpdateUI;
    }
    private void OnDisable()
    {
        // unsubscribe from inventory events
        GameEvents.OnItemAdded -= UpdateUI;
    }
    private void Awake()
    {
        // start with inventory closed animation
        animator.Play("InventoryClosed", 0, 1f); 
        // ensure inventory starts closed
        animator.SetBool("Open", false); 
    }

    public void ToggleInventory()
    {
        // need to add: gamemanager (hunger bar), bool variable to check if can open inventory
        // this is relevant in the kitchen when the keypad is open
        // if can't open inventory return;
        isOpen = !isOpen;
        if (DialogueManager.instance.isDialogueActive)
        {
            // if dialogue is active, prevent player from opening inventory
            return;
        }
        if (GameManager.instance.cutsceneActive)
        {
            // if cutscene is active, prevent player from opening inventory
            return;
        }

        // visually open inventory
        animator.SetBool("Open", isOpen);
        
        AudioManager.instance.PlayRandomSFX(uiSFX, this.transform, 0.5f);
    }

    private void UpdateUI(ItemData item)
    {
        // clear current inventory UI
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }

        // create new inventory slots for each item in inventory
        foreach (ItemData inventoryItem in InventoryManager.instance.items)
        {
            InventorySlot slot = Instantiate(slotPrefab, itemParent);
            slot.Setup(inventoryItem);
        }
    }
}
