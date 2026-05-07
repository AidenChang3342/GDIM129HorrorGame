using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text output;
    [SerializeField] private AudioClip[] buttonPressedSFX;
    [SerializeField] private string answer;
    public void KeyPressed(int input)
    {
        AudioManager.instance.PlayRandomSFX(buttonPressedSFX, this.transform, 1f);

        if (output.text.Length < 4)
        {
            output.text += input.ToString();
        }

    }

    public void Delete()
    {
        AudioManager.instance.PlayRandomSFX(buttonPressedSFX, this.transform, 1f);

        output.text = "";
    }

    public void Check()
    {
        AudioManager.instance.PlayRandomSFX(buttonPressedSFX, this.transform, 1f);

        if (output.text == answer)
        {
            Debug.Log("correct code");
        }
        else
        {
            output.text = "";
        }
    }
}
