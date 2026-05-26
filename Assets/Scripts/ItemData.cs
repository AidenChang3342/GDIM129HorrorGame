using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    //scriptable object for item data, used for inventory and item pickups
    public string itemName;
    // itemColor is temporary placeholder
    // to actually implement, this needs to be a sprite
    // could possibly have separate sprites for inventory icon and inspection image
    public Color itemColor;
    public Sprite itemSprite;
    public Sprite inspectionSprite;
    public List<string> itemDescription;
}
