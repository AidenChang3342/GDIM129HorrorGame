using UnityEngine;
using UnityEngine.UI;

public class HungerUI : MonoBehaviour
{
    [SerializeField] private Slider hungrySlider;
    [SerializeField] private GameObject hungerPanel;

    private void Start()
    {
        Show();

        if (HungryBarManager.instance != null)
        {
            SetValue(HungryBarManager.instance.HungerPercent);
        }
    }

    public void Show()
    {
        hungerPanel.SetActive(true);
    }

    public void Hide()
    {
        hungerPanel.SetActive(false);
    }

    public void SetValue(float value)
    {
        hungrySlider.value = value;
    }
}