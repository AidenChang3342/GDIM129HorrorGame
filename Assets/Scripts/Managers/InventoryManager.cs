using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }
    // list of items in inventory, can be accessed from anywhere using singleton
    public List<ItemData> items = new List<ItemData>();


    private void Awake()
    {
        // creating singleton to call from anywhere
        if (instance == null)
        {
            instance = this;
            // keep sounds playing between scenes
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // function to add item to inventory
    public void AddItem(ItemData item)
    {
        // check if item isn't already in inventory before adding
        if(!items.Contains(item))
        {
            items.Add(item);

            // call event when item is added to inventory, affects dialogue
            GameEvents.OnItemAdded?.Invoke(item);
        }
    }
}
