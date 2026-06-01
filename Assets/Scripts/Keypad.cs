using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    // output text
    [SerializeField] private TMP_Text output;
    // keypad sfx
    [SerializeField] private AudioClip[] buttonPressedSFX;
    // ui sfx
    [SerializeField] private AudioClip[] UISoundClip;
    // wrong code sfx
    [SerializeField] private AudioClip wrongcodeSFX;
    [SerializeField] private AudioClip correctcodeSFX;

    // correct code string
    [SerializeField] private string answer;

    [SerializeField] private GameObject snack;


    // hides keypad
    public void Exit()
    {
        AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 0.5f);
        this.gameObject.SetActive(false);
    }

    // inputs keypad number into output text
    public void KeyPressed(int input)
    {
        AudioManager.instance.PlayRandomSFX(buttonPressedSFX, this.transform, 1f);

        if (output.text.Length < 4)
        {
            output.text += input.ToString();
        }

    }

    // deletes the whole output string
    public void Delete()
    {
        AudioManager.instance.PlayRandomSFX(buttonPressedSFX, this.transform, 1f);

        output.text = "";
    }

    // checks if the current output text equals the answer key
    public void Check()
    {
        AudioManager.instance.PlayRandomSFX(buttonPressedSFX, this.transform, 1f);

        if (output.text == answer)
        {
            AudioManager.instance.PlaySFX(correctcodeSFX, this.transform, 1f);
            snack.SetActive(true);
        }
        else
        {
             AudioManager.instance.PlaySFX(wrongcodeSFX, this.transform, 1f);
            output.text = "";
        }
    }
}
