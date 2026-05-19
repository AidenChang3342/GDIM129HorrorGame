using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform itemParent;
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Animator animator;
    private bool isOpen = false;
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
    private void Start()
    {
        // hide inventory UI on start
        itemParent.gameObject.SetActive(false);

        animator.SetBool("Open", false); // ensure inventory starts closed
    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;
        animator.SetBool("Open", isOpen);

        // call events for opening and closing inventory, affects dialogue
        if (isOpen)
        {
            GameEvents.OnInventoryOpened?.Invoke();
        }
        else
        {
            GameEvents.OnInventoryClosed?.Invoke();
        }
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
