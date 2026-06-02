using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public void OnMouseDown()
    {
        // checks if dialogue is active or inventory is open before allowing scene change
        if (DialogueManager.instance.isDialogueActive)
        {
            Debug.Log("Cannot change scene while dialogue is active");
            return;
        }
        if (UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot change scene while inventory is opened");
            return;
        }
        GameManager.instance.ChangeScene(sceneToLoad);

        // set gameobject to inactive so it cannot be clicked again while transition is happening
        this.gameObject.SetActive(false);
    }
}
