using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public DialogueUI dialogueUI;
    public InventoryUI inventoryUI;
    public InspectionUI inspectionUI;


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

        // cache dialogueUI and inventoryUI references to prevent errors
        dialogueUI = GetComponentInChildren<DialogueUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();
        inspectionUI = GetComponentInChildren<InspectionUI>();
    }
    private void Start()
    {
        // call event to cache dialogueUI reference for dialogue manager
        GameEvents.OnUIReady?.Invoke();
    }
}
