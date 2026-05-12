using UnityEngine;
using TMPro;

public class HoverText : MonoBehaviour
{
    [SerializeField] private GameObject hoverArrow;

    private void Start()
    {
        hoverArrow.SetActive(false);
    }

    private void OnMouseEnter()
    {
        hoverArrow.SetActive(true);
    }

    private void OnMouseExit()
    {
        hoverArrow.SetActive(false);
    }
}