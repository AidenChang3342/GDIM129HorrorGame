using UnityEngine;
using UnityEngine.UI;

public class InspectionUI : MonoBehaviour
{
    public static InspectionUI instance;

    [SerializeField] private Image inspectImage;
    public GameObject inspection;

    private void Awake()
    {
        instance = this;
    }

    public void ShowItem(ItemData item)
    {
        inspection.SetActive(true);

        inspectImage.sprite = item.inspectionSprite;
        inspectImage.preserveAspect = true;
        inspectImage.SetNativeSize(); // important

    }

    public void CloseInspection()
    {
        inspection.SetActive(false);
    }
}
