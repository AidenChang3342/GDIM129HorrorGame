using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIClickDebug : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult result in results)
            {
                Debug.Log("Clicked UI: " + result.gameObject.name);
            }
        }
    }
}