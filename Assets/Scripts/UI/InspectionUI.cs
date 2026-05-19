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

        // this is only temporary, replace color with actual sprite
        // inspectImage.sprite = item.itemSprite
        // once this is done, remember to change the itemData to include the sprite
        inspectImage.color = item.itemColor;
    }

    public void CloseInspection()
    {
        inspection.SetActive(false);
    }
}
