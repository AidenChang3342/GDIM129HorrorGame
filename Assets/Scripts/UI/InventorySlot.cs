using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    private ItemData item;

    public void Setup(ItemData newItem)
    {
        item = newItem;
        itemImage.color = item.itemColor;
    }

    public void OnClick()
    {
        InspectionUI.instance.ShowItem(item);
        GameEvents.InspectionItemClicked?.Invoke(item.itemDescription);
    }
}