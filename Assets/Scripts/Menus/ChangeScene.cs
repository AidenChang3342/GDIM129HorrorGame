using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public void OnMouseDown()
    {
        GameManager.instance.ChangeScene(sceneToLoad);
    }
    public void Quit()
    {
        GameManager.instance.ExitGame();
    }
}
