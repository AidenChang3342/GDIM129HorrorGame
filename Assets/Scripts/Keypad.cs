using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text output;
    [SerializeField] private AudioClip[] buttonPressedSFX;
    public void KeyPressed(int input)
    {
        AudioManager.instance.PlayRandomSFX(buttonPressedSFX, this.transform, 1f);
        output.text += input.ToString();
    }
}
