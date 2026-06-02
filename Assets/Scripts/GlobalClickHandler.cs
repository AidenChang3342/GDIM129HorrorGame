using UnityEngine;

public class GlobalClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (DialogueManager.instance.isDialogueActive) return;
        if (UIManager.instance.inventoryUI.isOpen) return;

        HungryBarManager.instance.Decrease();
    }
}