using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Clicked hunger object");

        if (HungryBarManager.instance == null)
        {
            Debug.LogError("HungryBarManager instance is null");
            return;
        }

        HungryBarManager.instance.Decrease();
    }
}