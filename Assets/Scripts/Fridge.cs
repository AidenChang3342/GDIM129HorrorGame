using UnityEngine;

public class Fridge : MonoBehaviour
{
    // keypad object to set active/show
    [SerializeField] private GameObject keypad;
    // ui sfx
    [SerializeField] private AudioClip[] UISoundClip;

    public void ShowKeypad()
    {
        // prevents keypad from opening if inventory is open or dialogue is happening
        if (DialogueManager.instance.isDialogueActive || UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while dialogue/inventory open");
            return;
        }

        if (keypad.activeSelf == false)
        {
            AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 1f);

            keypad.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        // prevents keypad from opening if inventory is open or dialogue is happening
        if (DialogueManager.instance.isDialogueActive || UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot interact while dialogue/inventory open");
            return;
        }

        Debug.Log("Clicked Keypad ");
        AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 1f);
        keypad.SetActive(true);
    }
}
