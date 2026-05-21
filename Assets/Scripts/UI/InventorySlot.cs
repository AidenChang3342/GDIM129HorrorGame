using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    private ItemData item;

    public void Setup(ItemData newItem)
    {
        item = newItem;
        // this is only temporary, replace color with actual sprite
        // itemImage.sprite = item.itemSprite
        // once this is done, remember to change the itemData to include the sprite
        itemImage.color = item.itemColor;
    }

    public void OnClick()
    {
        InspectionUI.instance.ShowItem(item);
        GameEvents.InspectionItemClicked?.Invoke(item.itemDescription);

        UIManager.instance.inventoryUI.ToggleInventory();
    }
}