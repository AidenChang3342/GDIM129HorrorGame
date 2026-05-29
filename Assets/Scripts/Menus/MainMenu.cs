using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string startScene;
    public void StartGame()
    {
        GameManager.instance.ResetGame();
        GameManager.instance.ChangeScene(startScene);

        // later: start intro sequence with dialogue, sfx, and tutorial (tutorial is just a tooltip)
    }
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
