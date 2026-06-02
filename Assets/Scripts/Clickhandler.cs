using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        HungryBarManager.Instance.Decrease();
    }
}