using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerPrefab;
    [SerializeField] private GameObject inventoryManagerPrefab;
    
    private void Awake()
    {
        // check if audio manager already exists before instantiating
        if (AudioManager.instance == null)
        {
            Instantiate(audioManagerPrefab);
        }
        
        // check if inventory manager already exists before instantiating
        if (InventoryManager.instance == null)
        {
            Instantiate(inventoryManagerPrefab);
        }
    }
}
