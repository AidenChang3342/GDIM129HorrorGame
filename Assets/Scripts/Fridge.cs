using UnityEngine;

public class Fridge : MonoBehaviour
{
    // keypad object to set active/show
    [SerializeField] private GameObject keypad;
    // ui sfx
    [SerializeField] private AudioClip[] UISoundClip;

    public void ShowKeypad()
    {
        if (keypad.activeSelf == false)
        {
            AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 1f);

            keypad.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Clicked Keypad ");
        AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 1f);
        keypad.SetActive(true);
    }
}
