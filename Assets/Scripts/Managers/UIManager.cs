using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public DialogueUI dialogueUI;
    public InventoryUI inventoryUI;
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
}
