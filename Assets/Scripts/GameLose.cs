using UnityEngine;

public class GameLose : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("Restart clicked");
        GameManager.instance.RestartGame();
    }
}