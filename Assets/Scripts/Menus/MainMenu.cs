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

        // set gameobject to inactive so it cannot be clicked again while transition is happening
        this.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
