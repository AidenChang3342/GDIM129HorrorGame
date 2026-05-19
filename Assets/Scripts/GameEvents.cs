using System;
using UnityEngine;

public static class GameEvents
{
    // event for when item is added to inventory
    public static Action<ItemData> OnItemAdded;

    // event for when inventory is opened
    public static Action OnInventoryOpened;

    // event for when inventory is closed
    public static Action OnInventoryClosed;
}
