using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isMouseOverInventory;
    private void Start()
    {
        isMouseOverInventory = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("mouse over");
        isMouseOverInventory = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOverInventory = false;
        UnityEngine.Debug.Log("mouse over");

        // closes inventory when mouse leaves if the inventory is open
        if(UIManager.instance.inventoryUI.isOpen)
        {
            UIManager.instance.inventoryUI.ToggleInventory();
        }
    }
}
