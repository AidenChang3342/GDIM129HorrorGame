using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    private ItemData item;

    public void Setup(ItemData newItem)
    {
        item = newItem;
        itemImage.sprite = item.itemSprite;
        itemImage.preserveAspect = true;
        itemImage.enabled = item.itemSprite != null;
    }

    public void OnClick()
    {
        InspectionUI.instance.ShowItem(item);
        UIManager.instance.inventoryUI.ToggleInventory();
        DialogueManager.instance.StartDialogue(item.itemDescription); 
    }
}