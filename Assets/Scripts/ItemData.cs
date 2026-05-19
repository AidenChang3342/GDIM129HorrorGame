using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    //scriptable object for item data, used for inventory and item pickups
    public string itemName;
    public Color itemColor;
}
