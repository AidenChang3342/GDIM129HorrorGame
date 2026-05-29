using System;
using UnityEngine;
using System.Collections.Generic;

public static class GameEvents
{
    // event for when item is added to inventory
    public static Action<ItemData> OnItemAdded;
    // event for when inventory is opened
    public static Action OnInventoryOpened;
    // event for when inventory is closed
    public static Action OnInventoryClosed;
    // event for when inventory item is clicked for inspection
    public static Action<List<string>> InspectionItemClicked;
    // event for caching dialogueUI for dialogue to prevent errors
    public static Action OnUIReady;
    // event for activating keypad in kitchen
    public static Action ActivateKeypad;
}
