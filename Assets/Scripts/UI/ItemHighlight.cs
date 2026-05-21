using UnityEngine;

public class ItemHighlight : MonoBehaviour
{
    [SerializeField] private GameObject glowObject;

    private void Start()
    {
        glowObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        glowObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        glowObject.SetActive(false);
    }
}
