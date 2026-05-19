using UnityEngine;
using UnityEngine.UI;

public class InspectionUI : MonoBehaviour
{
    public static InspectionUI instance;

    [SerializeField] private Image inspectImage;

    private void Awake()
    {
        instance = this;
    }

    public void ShowItem(ItemData item)
    {
        gameObject.SetActive(true);
        inspectImage.color = item.itemColor;
    }

    public void CloseInspection()
    {
        gameObject.SetActive(false);
    }
}
