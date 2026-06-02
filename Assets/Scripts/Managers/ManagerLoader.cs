using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerPrefab;
    [SerializeField] private GameObject inventoryManagerPrefab;
    [SerializeField] private GameObject dialogueManagerPrefab;
    [SerializeField] private GameObject uiManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;
    [SerializeField] private GameObject hungerManagerPrefab;
    
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
        
        // check if dialogue manager already exists before instantiating
        if (DialogueManager.instance == null)
        {
            Instantiate(dialogueManagerPrefab);
        }

        // check if ui manager already exists before instantiating
        if (UIManager.instance == null)
        {
            Instantiate(uiManagerPrefab);
        }
        // check if game manager already exists before instantiating
        if (GameManager.instance == null)
        {
            Instantiate(gameManagerPrefab);
        }
        if (HungryBarManager.instance == null)
        {
            Instantiate(hungerManagerPrefab);
        }
    }
}
