using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string startScene;
    [SerializeField] private GameObject introCutscenePrefab;
    public void StartGame()
    {
        GameManager.instance.ResetGame();
        Instantiate(introCutscenePrefab);
        GameManager.instance.ChangeScene(startScene);
    }
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
